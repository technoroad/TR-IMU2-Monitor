using HelixToolkit.Wpf;
using System;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Brushes = System.Windows.Media.Brushes;

public partial class HelixViewManager
{
    public void BlowseColorCube()
    {
        var cube = CreateColoredCube();

        if (cube == null) return;

        // 既存を外して差し替え
        if (target3D != null)
            root.Children.Remove(target3D);

        target3D = cube;

        root.Children.Add(target3D);
        EnableSilhouetteOverlay(Colors.Black, 2.0);
    }

    private ModelVisual3D CreateColoredCube()
    {
        if (now_browse_model == "cube") return null;
        now_browse_model = "cube";

        var group = new Model3DGroup();

        // 各面の座標と色
        var faces = new[]
        {
            (new Point3D(-1,-1, 1), new Point3D( 1,-1, 1), new Point3D( 1, 1, 1), new Point3D(-1, 1, 1), Brushes.Blue), // 上面
            (new Point3D(-1,-1,-1), new Point3D( 1,-1,-1), new Point3D( 1, 1,-1), new Point3D(-1, 1,-1), Brushes.DeepSkyBlue),       // 底面
            (new Point3D(-1,-1,-1), new Point3D(-1,-1, 1), new Point3D(-1, 1, 1), new Point3D(-1, 1,-1), Brushes.Magenta),  // 右面
            (new Point3D( 1,-1,-1), new Point3D( 1,-1, 1), new Point3D( 1, 1, 1), new Point3D( 1, 1,-1), Brushes.OrangeRed),    // 左面
            (new Point3D(-1, 1,-1), new Point3D( 1, 1,-1), new Point3D( 1, 1, 1), new Point3D(-1, 1, 1), Brushes.LimeGreen),       // 背面
            (new Point3D(-1,-1,-1), new Point3D( 1,-1,-1), new Point3D( 1,-1, 1), new Point3D(-1,-1, 1), Brushes.Yellow)   // 前面
        };

        foreach (var (p1, p2, p3, p4, brush) in faces)
        {
            var mesh = new MeshGeometry3D
            {
                Positions = new Point3DCollection { p1, p2, p3, p4 },
                TriangleIndices = new Int32Collection { 0, 1, 2, 0, 2, 3 }
            };

            var material = new DiffuseMaterial(brush);
            var backMaterial = new DiffuseMaterial(brush);
            group.Children.Add(new GeometryModel3D(mesh, material) { BackMaterial = backMaterial });
        }
        return new ModelVisual3D { Content = group };
    }

    // CreateWorldAxesVisual の中で group を作っている前提
    private static ModelVisual3D CreateWorldAxesVisual(
        double axisLength,
        double shaftRadius,
        double headLength,
        double headRadius,
        int segments = 24)
    {
        var group = new Model3DGroup();

        // X/Y/Z の矢印モデル追加
        group.Children.Add(CreateAxisModel(new Vector3D(1, 0, 0), axisLength, shaftRadius, headLength, headRadius, Colors.Red, segments));
        group.Children.Add(CreateAxisModel(new Vector3D(0, 1, 0), axisLength, shaftRadius, headLength, headRadius, Colors.LimeGreen, segments));
        group.Children.Add(CreateAxisModel(new Vector3D(0, 0, 1), axisLength, shaftRadius, headLength, headRadius, Colors.Blue, segments));

        // 3Dモデル（矢印）本体
        var axesVisual = new ModelVisual3D { Content = group };

        //return axesVisual;

        // ラベルをまとめて子要素としてぶら下げる（回転同期したい場合にも都合が良い）
        var root = new ModelVisual3D();
        root.Children.Add(axesVisual);

        // ラベル位置（矢印先端より少し先）
        double labelOffset = axisLength + headLength * 0.35;

        // Xラベル（赤）
        root.Children.Add(new BillboardTextVisual3D
        {
            Text = "X",
            Foreground = Brushes.Red,
            Background = Brushes.Transparent,
            Position = new Point3D(labelOffset, -0.35, 0),
            FontSize = 16
        });

        // Yラベル（緑）
        root.Children.Add(new BillboardTextVisual3D
        {
            Text = "Y",
            Foreground = Brushes.LimeGreen,
            Background = Brushes.Transparent,
            Position = new Point3D(0.35, labelOffset, 0),
            FontSize = 16
        });

        // Zラベル（青）
        root.Children.Add(new BillboardTextVisual3D
        {
            Text = "Z",
            Foreground = Brushes.Blue,
            Background = Brushes.Transparent,
            Position = new Point3D(0, 0, labelOffset),
            FontSize = 16
        });

        return root;
    }

    private static GeometryModel3D CreateAxisModel(
        Vector3D dir,
        double length,
        double shaftRadius,
        double headLength,
        double headRadius,
        Color color,
        int segments)
    {
        dir.Normalize();

        // 軸の棒（円柱）: 0 -> (length - headLength)
        var shaft = CreateCylinder(
            p0: new Point3D(0, 0, 0),
            p1: new Point3D(dir.X * (length - headLength), dir.Y * (length - headLength), dir.Z * (length - headLength)),
            radius: shaftRadius,
            segments: segments);

        // 矢印（円錐）: (length - headLength) -> length
        var cone = CreateCone(
            baseCenter: new Point3D(dir.X * (length - headLength), dir.Y * (length - headLength), dir.Z * (length - headLength)),
            tip: new Point3D(dir.X * length, dir.Y * length, dir.Z * length),
            baseRadius: headRadius,
            segments: segments);

        // 結合
        var mesh = new MeshGeometry3D();
        AppendMesh(mesh, shaft);
        AppendMesh(mesh, cone);

        var mat = new DiffuseMaterial(new SolidColorBrush(color));

        // 反転変換（-1スケール等）を入れると法線が裏返りやすいので両面に
        var gm = new GeometryModel3D
        {
            Geometry = mesh,
            Material = mat,
            BackMaterial = mat
        };

        return gm;
    }

    private static void AppendMesh(MeshGeometry3D dst, MeshGeometry3D src)
    {
        int offset = dst.Positions.Count;
        foreach (var p in src.Positions) dst.Positions.Add(p);
        foreach (var n in src.Normals) dst.Normals.Add(n);
        foreach (var t in src.TriangleIndices) dst.TriangleIndices.Add(t + offset);
    }

    /// <summary>
    /// 2点間に円柱メッシュを作る（WPF純正 MeshGeometry3D）。
    /// </summary>
    private static MeshGeometry3D CreateCylinder(Point3D p0, Point3D p1, double radius, int segments)
    {
        var mesh = new MeshGeometry3D();

        Vector3D axis = p1 - p0;
        double height = axis.Length;
        if (height < 1e-9) return mesh;

        axis.Normalize();

        // 軸に直交する2ベクトル（u,v）を作る
        Vector3D tmp = Math.Abs(axis.Z) < 0.99 ? new Vector3D(0, 0, 1) : new Vector3D(0, 1, 0);
        Vector3D u = Vector3D.CrossProduct(axis, tmp);
        u.Normalize();
        Vector3D v = Vector3D.CrossProduct(axis, u);
        v.Normalize();

        // 円周の頂点（下/上）
        for (int i = 0; i <= segments; i++)
        {
            double a = 2.0 * Math.PI * i / segments;
            Vector3D r = Math.Cos(a) * u * radius + Math.Sin(a) * v * radius;
            var pb = p0 + r;
            var pt = p1 + r;

            mesh.Positions.Add(pb);
            mesh.Positions.Add(pt);

            // 法線は側面方向
            Vector3D normal = r;
            normal.Normalize();
            mesh.Normals.Add(normal);
            mesh.Normals.Add(normal);
        }

        // 側面の三角形
        for (int i = 0; i < segments; i++)
        {
            int i0 = i * 2;
            int i1 = i0 + 1;
            int i2 = i0 + 2;
            int i3 = i0 + 3;

            // (i0, i2, i1) と (i2, i3, i1)
            mesh.TriangleIndices.Add(i0);
            mesh.TriangleIndices.Add(i2);
            mesh.TriangleIndices.Add(i1);

            mesh.TriangleIndices.Add(i2);
            mesh.TriangleIndices.Add(i3);
            mesh.TriangleIndices.Add(i1);
        }

        return mesh;
    }

    /// <summary>
    /// 円錐（矢印ヘッド）メッシュを作る（底面は作らず側面のみ）。
    /// </summary>
    private static MeshGeometry3D CreateCone(Point3D baseCenter, Point3D tip, double baseRadius, int segments)
    {
        var mesh = new MeshGeometry3D();

        Vector3D axis = tip - baseCenter;
        double height = axis.Length;
        if (height < 1e-9) return mesh;

        axis.Normalize();

        Vector3D tmp = Math.Abs(axis.Z) < 0.99 ? new Vector3D(0, 0, 1) : new Vector3D(0, 1, 0);
        Vector3D u = Vector3D.CrossProduct(axis, tmp);
        u.Normalize();
        Vector3D v = Vector3D.CrossProduct(axis, u);
        v.Normalize();

        // 先端
        int tipIndex = 0;
        mesh.Positions.Add(tip);
        mesh.Normals.Add(axis); // 仮

        // 底周り
        for (int i = 0; i <= segments; i++)
        {
            double a = 2.0 * Math.PI * i / segments;
            Vector3D r = Math.Cos(a) * u * baseRadius + Math.Sin(a) * v * baseRadius;
            var p = baseCenter + r;

            mesh.Positions.Add(p);

            // 側面法線（だいたいでOK）
            Vector3D side = p - tip;
            Vector3D normal = side - Vector3D.Multiply(Vector3D.DotProduct(side, axis), axis);
            if (normal.Length > 1e-9) normal.Normalize();
            else normal = u;

            mesh.Normals.Add(normal);
        }

        // 三角形（側面） tip(0) と (1..segments+1) の扇形
        for (int i = 1; i <= segments; i++)
        {
            mesh.TriangleIndices.Add(tipIndex);
            mesh.TriangleIndices.Add(i);
            mesh.TriangleIndices.Add(i + 1);
        }

        return mesh;
    }
}
