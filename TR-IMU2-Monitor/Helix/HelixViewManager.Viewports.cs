using HelixToolkit.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Numerics;
using Quaternion = System.Windows.Media.Media3D.Quaternion;
using System.Windows.Forms.Integration;
using Control = System.Windows.Forms.Control;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System;
using System.Windows.Forms;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using System.Windows.Interop;
using Panel = System.Windows.Forms.Panel;
using Button = System.Windows.Controls.Button;
using ComboBox = System.Windows.Controls.ComboBox;
using Orientation = System.Windows.Controls.Orientation;
using ToggleButton = System.Windows.Controls.Primitives.ToggleButton;
using System.Reflection.Emit;

public partial class HelixViewManager
{
    public Panel viewer = new Panel();
    private ElementHost host = new ElementHost();
    private ModelVisual3D hudRoot = new ModelVisual3D();        // HUD 側のルート
    private AmbientLight mainLight = new AmbientLight();

    // インフォ情報をダブルクリックした時に行うイベント
    private readonly TextBlock info_lb = new TextBlock();
    private readonly TextBlock receiveStatusText = new TextBlock();
    private readonly Ellipse receiveStatusIndicator = new Ellipse();
    private StackPanel receiveStatusRow;
    private StackPanel controls;
    private Grid actions;
    private Border infoCard;
    private Border zoomButtonPanel;
    private Button zoomInButton;
    private Button zoomOutButton;
    private Button resetViewButton;
    private Button poseResetButton;
    private ComboBox viewPresetCombo;
    private ToggleButton hudToggleButton;
    private ToggleButton infoToggleButton;
    private bool hudEnabled = true;
    private int cameraAngle;
    private int cameraZoom = 14;
    private int hudZoom = 6;
    private bool updatingViewPreset;
    private bool overlayVisible;
    public event EventHandler InfoDoubleClicked;
    public event Action<int> CameraAngleChanged;

    /// <summary>
    /// Viewport作成・Grid重ね(メイン+HUD)・座標系変換の適用などをまとめた初期化。
    /// </summary>
    private void BuildViewports()
    {
        // Panelを親とする
        viewer.Dock = DockStyle.Fill;

        // WPFホスト
        host.Dock = DockStyle.Fill;
        viewer.Controls.Add(host);

        // Gridを作って「メイン + HUD」を重ねる
        var grid = new Grid();
        host.Child = grid;

        // ----------------------------
        // メイン HelixViewport3D
        // ----------------------------
        helixViewport = new HelixViewport3D();
        grid.Children.Add(helixViewport);

        helixViewport.Camera = new PerspectiveCamera
        {
            Position = new Point3D(0, 2, 6),
            LookDirection = new Vector3D(0, -2, -6),
            UpDirection = new Vector3D(0, 1, 0),
        };

        // 内蔵HUD座標軸は使わない（回転/座標変換に追従しない場合がある）
        helixViewport.ShowCoordinateSystem = false;

        // 座標系変換: (x', y', z') = (x, -z, y)
        var m = new Matrix3D(
            1, 0, 0, 0,
            0, 0, -1, 0,
            0, 1, 0, 0,
            0, 0, 0, 1);

        root.Transform = new MatrixTransform3D(m);
        helixViewport.Children.Add(root);

        mainLight = new AmbientLight(Darken(Colors.White, 1));

        root.Children.Add(new ModelVisual3D
        {
            Content = mainLight
        });

        SetBrightness(1);

        // ----------------------------
        // 左下HUD（ミニ HelixViewport3D）
        // ----------------------------
        hudViewport = new HelixViewport3D
        {
            Width = 100,
            Height = 100,
            Background = Brushes.Transparent,
            IsHitTestVisible = false,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Bottom,
            Visibility = Visibility.Hidden,
            Margin = new Thickness(2),

            // HUD側は表示専用（操作OFF）
            IsRotationEnabled = false,
            IsZoomEnabled = false,
            IsPanEnabled = false,
            ShowViewCube = false,
            ShowCoordinateSystem = false,
            ShowCameraInfo = false
        };

        grid.Children.Add(hudViewport);

        // HUD側ルート（メインと同じ座標系変換を適用）
        hudRoot.Transform = new MatrixTransform3D(m);
        hudViewport.Children.Add(hudRoot);

        hudViewport.Children.Add(new ModelVisual3D
        {
            Content = new AmbientLight(Darken(Colors.White, 1))
        });

        // HUDには「回転できる自作軸」だけ入れる
        coloredAxis = CreateWorldAxesVisual(
            axisLength: 2,
            shaftRadius: 0.1,
            headLength: 0.5,
            headRadius: 0.2);

        hudRoot.Children.Add(coloredAxis);

        //SetHudModel(coloredAxis);
        //EnableHudSilhouetteOverlay(Colors.Black);

        // HUDカメラ（メインと同じカメラ参照）
        hudViewport.Camera = new PerspectiveCamera
        {
            Position = new Point3D(0, 2, 6),
            LookDirection = new Vector3D(0, -2, -6),
            UpDirection = new Vector3D(0, 1, 0),
            FieldOfView = 45
        };

        // 3Dビュー上にForm1/Form2共通の情報カードと操作パネルを配置する。
        info_lb.HorizontalAlignment = HorizontalAlignment.Stretch;
        info_lb.VerticalAlignment = VerticalAlignment.Top;
        info_lb.TextWrapping = TextWrapping.Wrap;
        info_lb.Text = "Quaternion (WXYZ)  --\n姿勢角 (ZYX)  --\n描画  -- Hz";

        receiveStatusIndicator.Width = 8;
        receiveStatusIndicator.Height = 8;
        receiveStatusIndicator.Fill = new SolidColorBrush(Color.FromRgb(140, 148, 160));
        receiveStatusIndicator.Margin = new Thickness(0, 0, 6, 0);
        receiveStatusText.Text = "未受信";
        receiveStatusText.Foreground = new SolidColorBrush(Color.FromRgb(210, 216, 226));
        receiveStatusText.FontSize = 11;

        receiveStatusRow = new StackPanel { Orientation = Orientation.Horizontal };
        receiveStatusRow.Margin = new Thickness(0, 5, 0, 0);
        receiveStatusRow.VerticalAlignment = VerticalAlignment.Center;
        receiveStatusRow.Children.Add(receiveStatusIndicator);
        receiveStatusRow.Children.Add(receiveStatusText);

        var infoContent = new StackPanel();
        infoContent.Children.Add(info_lb);
        infoContent.Children.Add(receiveStatusRow);

        infoCard = new Border
        {
            Child = infoContent,
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(10),
            Padding = new Thickness(9, 6, 9, 6),
            Background = new SolidColorBrush(Color.FromArgb(218, 25, 31, 43)),
            BorderBrush = new SolidColorBrush(Color.FromArgb(100, 115, 155, 205)),
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(6),
            MaxWidth = 560,
            ToolTip = "マウスホイールでズーム"
        };
        System.Windows.Controls.Panel.SetZIndex(infoCard, 1);
        grid.Children.Add(infoCard);

        actions = new Grid
        {
            Width = 136,
            HorizontalAlignment = HorizontalAlignment.Right
        };
        for (int i = 0; i < 3; i++)
            actions.ColumnDefinitions.Add(new ColumnDefinition());
        for (int i = 0; i < 2; i++)
            actions.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        zoomInButton = CreateActionButton("＋", "拡大", () => ZoomCamera(true));
        zoomOutButton = CreateActionButton("−", "縮小", () => ZoomCamera(false));
        Grid.SetRow(zoomInButton, 0);
        Grid.SetColumn(zoomInButton, 0);
        actions.Children.Add(zoomInButton);
        Grid.SetRow(zoomOutButton, 1);
        Grid.SetColumn(zoomOutButton, 0);
        actions.Children.Add(zoomOutButton);
        resetViewButton = CreateActionButton("視点", "視点をリセット", ResetCamera);
        poseResetButton = CreateActionButton("姿勢", "姿勢をリセット", () => InfoDoubleClicked?.Invoke(this, EventArgs.Empty));
        Grid.SetRow(resetViewButton, 0);
        Grid.SetColumn(resetViewButton, 1);
        actions.Children.Add(resetViewButton);
        Grid.SetRow(poseResetButton, 0);
        Grid.SetColumn(poseResetButton, 2);
        actions.Children.Add(poseResetButton);

        hudToggleButton = CreateActionToggleButton("軸", "座標軸の表示切り替え", true);
        hudToggleButton.Checked += (sender, e) => SetHudVisible(true);
        hudToggleButton.Unchecked += (sender, e) => SetHudVisible(false);
        Grid.SetRow(hudToggleButton, 1);
        Grid.SetColumn(hudToggleButton, 1);
        actions.Children.Add(hudToggleButton);

        infoToggleButton = CreateActionToggleButton("情報", "数値情報の表示切り替え", true);
        infoToggleButton.Checked += (sender, e) => infoCard.Visibility = overlayVisible ? Visibility.Visible : Visibility.Collapsed;
        infoToggleButton.Unchecked += (sender, e) => infoCard.Visibility = Visibility.Collapsed;
        Grid.SetRow(infoToggleButton, 1);
        Grid.SetColumn(infoToggleButton, 2);
        actions.Children.Add(infoToggleButton);

        viewPresetCombo = new ComboBox
        {
            Width = 136,
            Height = 28,
            Margin = new Thickness(1),
            ToolTip = "視点を選択",
            ItemsSource = new[] { "0°", "90°", "180°", "270°" },
            SelectedIndex = 0
        };
        viewPresetCombo.SelectionChanged += ViewPresetCombo_SelectionChanged;

        controls = new StackPanel();
        controls.Children.Add(viewPresetCombo);
        controls.Children.Add(actions);

        zoomButtonPanel = new Border
        {
            Child = controls,
            Background = new SolidColorBrush(Color.FromArgb(216, 32, 38, 51)),
            BorderBrush = new SolidColorBrush(Color.FromArgb(110, 115, 155, 205)),
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(8),
            Padding = new Thickness(3),
            HorizontalAlignment = HorizontalAlignment.Right,
            VerticalAlignment = VerticalAlignment.Bottom,
            Margin = new Thickness(0, 0, 12, 12)
        };
        System.Windows.Controls.Panel.SetZIndex(zoomButtonPanel, 1);
        grid.Children.Add(zoomButtonPanel);

        UpdateInfoAppearance();
        UpdateZoomButtonEnabled();
        SetDisplayMode(false);
        SetOverlayVisibility(false);
        info_lb.MouseLeftButtonDown += info_lb_MouseLeftButtonDown;
    }

    private void UpdateInfoAppearance()
    {
        info_lb.Foreground = new SolidColorBrush(Color.FromRgb(242, 245, 250));
        info_lb.Background = Brushes.Transparent;
        info_lb.FontFamily = new FontFamily("Yu Gothic UI");
        info_lb.FontSize = 13;
        info_lb.FontWeight = FontWeights.Normal;
        info_lb.FontStyle = FontStyles.Normal;
    }

    private Button CreateActionButton(string content, string toolTip, Action action)
    {
        var button = new Button
        {
            Content = content,
            ToolTip = toolTip,
            Width = 40,
            Height = 36,
            Margin = new Thickness(1),
            Padding = new Thickness(0),
            FontSize = content.Length == 1 ? 20 : 11,
            FontWeight = content.Length == 1 ? FontWeights.Bold : FontWeights.Normal,
            Foreground = Brushes.White,
            Background = new SolidColorBrush(Color.FromRgb(48, 58, 76)),
            BorderBrush = new SolidColorBrush(Color.FromRgb(86, 111, 148)),
            Cursor = System.Windows.Input.Cursors.Hand
        };
        button.Click += (sender, e) => action();
        return button;
    }

    private ToggleButton CreateActionToggleButton(string content, string toolTip, bool isChecked)
    {
        return new ToggleButton
        {
            Content = content,
            ToolTip = toolTip,
            IsChecked = isChecked,
            Width = 40,
            Height = 36,
            Margin = new Thickness(1),
            Padding = new Thickness(0),
            FontSize = 11,
            Foreground = Brushes.White,
            Background = new SolidColorBrush(Color.FromRgb(48, 58, 76)),
            BorderBrush = new SolidColorBrush(Color.FromRgb(86, 111, 148)),
            Cursor = System.Windows.Input.Cursors.Hand
        };
    }

    private void ViewPresetCombo_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (updatingViewPreset || viewPresetCombo.SelectedIndex < 0) return;
        int angle = viewPresetCombo.SelectedIndex * 90;
        if (angle == cameraAngle) return;

        SetCamera(angle, cameraZoom, hudZoom);
        CameraAngleChanged?.Invoke(angle);
    }

    private void UpdateZoomButtonEnabled()
    {
        if (zoomInButton == null || zoomOutButton == null) return;
        bool enabled = helixViewport != null && helixViewport.IsZoomEnabled;
        zoomInButton.IsEnabled = enabled;
        zoomOutButton.IsEnabled = enabled;
    }

    public void SetDisplayMode(bool expanded)
    {
        if (viewPresetCombo == null) return;

        if (!expanded && infoToggleButton.IsChecked != true)
            infoToggleButton.IsChecked = true;

        var visibility = expanded ? Visibility.Visible : Visibility.Collapsed;
        viewPresetCombo.Visibility = visibility;
        receiveStatusRow.Visibility = visibility;
        resetViewButton.Visibility = visibility;
        poseResetButton.Visibility = visibility;
        hudToggleButton.Visibility = visibility;
        infoToggleButton.Visibility = visibility;
        actions.Width = expanded ? 136 : 44;
        actions.ColumnDefinitions[0].Width = expanded ? new GridLength(1, GridUnitType.Star) : new GridLength(44);
        actions.ColumnDefinitions[1].Width = expanded ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
        actions.ColumnDefinitions[2].Width = expanded ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
        zoomButtonPanel.Padding = expanded ? new Thickness(3) : new Thickness(2);
    }

    public void SetOverlayVisibility(bool visible)
    {
        overlayVisible = visible;
        if (zoomButtonPanel != null)
            zoomButtonPanel.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;

        if (infoCard != null)
            infoCard.Visibility = visible && infoToggleButton?.IsChecked == true
                ? Visibility.Visible
                : Visibility.Collapsed;
    }

    public void SetReceiveStatus(bool hasReceived, bool receiving)
    {
        if (!hasReceived)
        {
            receiveStatusText.Text = "未受信";
            receiveStatusIndicator.Fill = new SolidColorBrush(Color.FromRgb(140, 148, 160));
        }
        else if (receiving)
        {
            receiveStatusText.Text = "受信中";
            receiveStatusIndicator.Fill = new SolidColorBrush(Color.FromRgb(74, 190, 125));
        }
        else
        {
            receiveStatusText.Text = "受信停止";
            receiveStatusIndicator.Fill = new SolidColorBrush(Color.FromRgb(229, 91, 85));
        }
    }

    public void SetTelemetry(Quaternion q, Vector3 euler, int frameRate)
    {
        info_lb.Text =
            $"Quaternion (WXYZ)  {q.W:F3} | {q.X:F3} | {q.Y:F3} | {q.Z:F3}\n" +
            $"姿勢角 (ZYX)  {euler.Z:F3}° | {euler.Y:F3}° | {euler.X:F3}°\n" +
            $"描画  {frameRate} Hz";
    }

    public void SetInfoText(string text)
    {
        // 高さはWPFに任せ、テキストと背景をまとめて更新する。
        info_lb.Text = text ?? "";
    }

    public void ZoomCamera(bool zoomIn)
    {
        if (helixViewport == null || !helixViewport.IsZoomEnabled) return;
        var camera = helixViewport.Camera as ProjectionCamera;
        if (camera == null || camera.LookDirection.Length == 0) return;

        const double minDistance = 2.0;
        const double maxDistance = 60.0;
        var lookDirection = camera.LookDirection;
        var distance = lookDirection.Length;
        var nextDistance = Math.Max(minDistance, Math.Min(maxDistance, distance * (zoomIn ? 0.9 : 1.1)));
        var scale = nextDistance / distance;
        var target = camera.Position + lookDirection;
        camera.LookDirection = lookDirection * scale;
        camera.Position = target + (camera.Position - target) * scale;
    }

    private void info_lb_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        e.Handled = true;
        if (e.ClickCount == 2)
            InfoDoubleClicked?.Invoke(this, EventArgs.Empty);
    }

    public void ConfigCamera(ProjectionCamera camera, int deg, int zoom)
    {
        if (camera == null)
            throw new ArgumentNullException(nameof(camera));

        deg = ((deg % 360) + 360) % 360;
        double angle = zoom / 2.0;

        camera.UpDirection = new Vector3D(0, 1, 0);

        switch (deg)
        {
            case 0:
                camera.Position = new Point3D(0, angle, zoom);
                camera.LookDirection = new Vector3D(0, -angle, -zoom);
                break;

            case 90:
                camera.Position = new Point3D(-zoom, angle, 0);
                camera.LookDirection = new Vector3D(zoom, -angle, 0);
                break;

            case 180:
                camera.Position = new Point3D(0, angle, -zoom);
                camera.LookDirection = new Vector3D(0, -angle, zoom);
                break;

            case 270:
                camera.Position = new Point3D(zoom, angle, 0);
                camera.LookDirection = new Vector3D(-zoom, -angle, 0);
                break;

            default:
                throw new ArgumentException("deg must be 0, 90, 180, 270");
        }
    }

    public void SetCamera(int deg, int zoom, int hud_zoom)
    {
        if (helixViewport == null || hudViewport == null) return;
        cameraAngle = ((deg % 360) + 360) % 360;
        cameraZoom = zoom;
        hudZoom = hud_zoom;
        if (viewPresetCombo != null && viewPresetCombo.SelectedIndex != cameraAngle / 90)
        {
            updatingViewPreset = true;
            viewPresetCombo.SelectedIndex = cameraAngle / 90;
            updatingViewPreset = false;
        }
        ConfigCamera(helixViewport.Camera, cameraAngle, cameraZoom);
        ConfigCamera(hudViewport.Camera, cameraAngle, hudZoom);
    }

    public void ResetCamera()
    {
        if (helixViewport == null || hudViewport == null) return;
        SetCamera(cameraAngle, cameraZoom, hudZoom);
    }

    public void SetHudVisible(bool visible)
    {
        hudEnabled = visible;
        if (hudToggleButton != null && hudToggleButton.IsChecked != visible)
            hudToggleButton.IsChecked = visible;

        if (hudViewport == null) return;
        hudViewport.Visibility = visible && helixViewport != null && helixViewport.Visibility == Visibility.Visible
            ? Visibility.Visible
            : Visibility.Hidden;
    }
}
