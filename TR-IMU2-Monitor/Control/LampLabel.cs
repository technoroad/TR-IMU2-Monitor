using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

[Designer(typeof(GenericMoveSizeDesigner))]
[DesignerCategory("Code")]
public class LampLabel : UserControl, IDesignerMovable
{
    public enum LampShape
    {
        Square,
        Circle
    }

    private bool _checked = false;
    private Color _onColor = Color.LimeGreen;
    private Color _offColor = Color.DarkGray;

    private int _lampSize = 12;
    private const int MarginX = 4;

    private LampShape _shape = LampShape.Square;
    private bool _drawBorder = true;
    private bool _autoSize = true;

    #region 公開プロパティ

    [Browsable(true)]
    [Category("Design")]
    [DefaultValue(false)]
    public bool DesignerMovable { get; set; } = true;


    [Category("Appearance")]
    [DefaultValue(false)]
    public bool Checked
    {
        get => _checked;
        set
        {
            _checked = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color OnColor
    {
        get => _onColor;
        set
        {
            _onColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color OffColor
    {
        get => _offColor;
        set
        {
            _offColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(LampShape.Square)]
    public LampShape Shape
    {
        get => _shape;
        set
        {
            _shape = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public bool DrawBorder
    {
        get => _drawBorder;
        set
        {
            _drawBorder = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(12)]
    public int LampSize
    {
        get => _lampSize;
        set
        {
            if (value < 4) value = 4;   // 最小サイズ保護
            _lampSize = value;
            Invalidate();
            PerformLayout();           // AutoSize対応
        }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public override bool AutoSize
    {
        get => _autoSize;
        set
        {
            _autoSize = value;
            DesignerMovable = value;
            Invalidate();
        }
    }

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override string Text
    {
        get => base.Text;
        set
        {
            if (base.Text == value) return;
            base.Text = value;
            Invalidate();        // 再描画要求
            PerformLayout();     // AutoSize 対応
        }
    }
    #endregion

    public LampLabel()
    {
        DoubleBuffered = true;
        Enabled = true;
    }

    protected override void OnFontChanged(EventArgs e)
    {
        base.OnFontChanged(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (_autoSize)
        {
            Size textSize = TextRenderer.MeasureText(Text, Font);
            Width = LampSize + MarginX * 3 + textSize.Width;
            Height = Math.Max(LampSize + MarginX * 2, textSize.Height + MarginX * 2);
        }

        var g = e.Graphics;

        Color lampBaseColor = Checked ? OnColor : OffColor;

        // 無効時は薄くする
        Color lampColor = Enabled
            ? lampBaseColor
            : ControlPaint.Light(lampBaseColor);

        Color textColor = Enabled
            ? ForeColor
            : SystemColors.GrayText;

        int lampY = (Height - LampSize) / 2;

        Rectangle lampRect = new Rectangle(
            MarginX,
            lampY,
            LampSize,
            LampSize
        );

        using (var b = new SolidBrush(lampColor))
        {
            if (Shape == LampShape.Circle)
                g.FillEllipse(b, lampRect);
            else
                g.FillRectangle(b, lampRect);
        }

        if (DrawBorder)
        {
            if (Shape == LampShape.Circle)
                g.DrawEllipse(Pens.Black, lampRect);
            else
                g.DrawRectangle(Pens.Black, lampRect);
        }

        TextRenderer.DrawText(
            g,
            Text,
            Font,
            new Point(LampSize + MarginX * 2, (Height - Font.Height) / 2),
            textColor
        );
    }
}
