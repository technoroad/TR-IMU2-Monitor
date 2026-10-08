using System;
using System.Windows.Media;

public partial class HelixViewManager
{
    private static Color Darken(Color c, double factor)
    {
        // factor: 0.0～1.0（例：0.8で少し暗く、0.5でかなり暗く）
        factor = Math.Max(0.0, Math.Min(1.0, factor));
        return Color.FromArgb(
            c.A,
            (byte)Math.Max(0, Math.Min(255, (int)(c.R * factor))),
            (byte)Math.Max(0, Math.Min(255, (int)(c.G * factor))),
            (byte)Math.Max(0, Math.Min(255, (int)(c.B * factor)))
        );
    }
}
