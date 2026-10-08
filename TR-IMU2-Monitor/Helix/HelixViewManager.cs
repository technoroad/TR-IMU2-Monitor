using HelixToolkit.Wpf;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Reflection;
using System.IO;

public partial class HelixViewManager
{
    // Root for main scene (座標系変換もここに適用)
    private readonly ModelVisual3D root = new ModelVisual3D();

    private HelixViewport3D helixViewport;
    private HelixViewport3D hudViewport; // 左下HUD

    private ModelVisual3D target3D;
    private ModelVisual3D coloredAxis;
    private GridLinesVisual3D gridVisual;

    private string now_browse_model = "none";

    /// <summary>
    /// WinFormsの親ControlにWPF(HelixViewport3D)をホストします。
    /// </summary>
    public void Initialize()
    {
        BuildViewports();

        BlowseColorCube();

        // 既存設定
        helixViewport.Visibility = Visibility.Hidden;
        helixViewport.IsRotationEnabled = false;
        helixViewport.IsZoomEnabled = false;
        helixViewport.IsPanEnabled = false;
        helixViewport.ShowCameraInfo = false;
        helixViewport.ShowViewCube = false;
        helixViewport.ShowTriangleCountInfo = false;
        helixViewport.ShowCameraTarget = false;
    }


    public void ShowGrid(
        double width = 20,
        double length = 20,
        double minor = 1,
        double major = 5,
        double thickness = 0.02,
        Brush color = null)
    {

        if (color == null)
        {
            color = Brushes.DimGray;
        }


        // 既存があれば消す
        if (gridVisual != null)
            root.Children.Remove(gridVisual);

        gridVisual = new GridLinesVisual3D
        {
            Width = width,
            Length = length,
            MinorDistance = minor,
            MajorDistance = major,
            Thickness = thickness,
            Fill = color,
            Center = new Point3D(0, 0, 0),
            Normal = new Vector3D(0, 0, 1),          // XY平面に出す（Zが法線）
            LengthDirection = new Vector3D(0, 1, 0), // 方向の基準
            Visible = true
        };

        // モデルと同じ座標系にするため root 配下に置く [3](https://github.com/helix-toolkit/helix-toolkit)
        root.Children.Add(gridVisual);
    }

    public void RemoveGrid()
    {
        // 既存があれば消す
        if (gridVisual != null)
            root.Children.Remove(gridVisual);
    }


    public void LoadObj(string path , string unique)
    {
        if (now_browse_model == unique) return;
        now_browse_model = unique;

        var importer = new ModelImporter();
        var modelGroup = importer.Load(path, dispatcher: null, freeze: true);
        if (modelGroup == null) return;

        // 既存を外して差し替え
        if (target3D != null)
            root.Children.Remove(target3D);

        target3D = new ModelVisual3D { Content = modelGroup };

        root.Children.Add(target3D);
        EnableSilhouetteOverlay(Colors.Black, 2.0);
    }

    public void SetVisility(bool visible)
    {
        if (helixViewport == null || hudViewport == null) return;

        if (visible)
        {
            helixViewport.Visibility = Visibility.Visible;
            hudViewport.Visibility = hudEnabled ? Visibility.Visible : Visibility.Hidden;
        }
        else
        {
            helixViewport.Visibility = Visibility.Hidden;
            hudViewport.Visibility = Visibility.Hidden;
        }

        SetOverlayVisibility(visible);
    }

    public void UpdateCubeRotation(Quaternion q)
    {
        if (target3D == null || coloredAxis == null) return;

        var rotation = new RotateTransform3D(new QuaternionRotation3D(q));
        target3D.Transform = rotation;
        coloredAxis.Transform = rotation;

        _mainSilhouette?.SyncTransform();
        _hudSilhouette?.SyncTransform();
    }

    public void ZoomEnable(bool en)
    {
        if (helixViewport == null) return;
        helixViewport.IsZoomEnabled = en;
        UpdateZoomButtonEnabled();
    }

    public bool ZoomEnabled()
    {
        if (helixViewport == null) { return false; }
        return helixViewport.IsZoomEnabled;
    }

    public void SetHudSize(int size)
    {
        if (hudViewport == null) return;
        hudViewport.Width = size;
        hudViewport.Height = size;
    }

    public int GetHudSize()
    {
        if (hudViewport == null) return 0;
        return (int)hudViewport.Width;
    }

    public void SetHudCamera(ProjectionCamera camera)
    {
        if (hudViewport == null) return;
        hudViewport.Camera = camera;
    }

    public ProjectionCamera GetHudCamera()
    {
        return hudViewport.Camera;
    }

    private double brightness = 1;

    public void SetBrightness(double b)
    {
        if(brightness != b)
        {
            mainLight.Color = Darken(Colors.White, b);
        }
    }
}
