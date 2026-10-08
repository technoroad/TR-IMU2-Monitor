using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Media3D;

public partial class HelixViewManager
{
    //===============================
    // メイン／HUD 用インスタンス
    //===============================
    private SilhouetteOverlayRenderer _mainSilhouette;
    private SilhouetteOverlayRenderer _hudSilhouette;

    // overlays
    private LinesVisual3D silhouetteLines;
    private LinesVisual3D hudSilhouetteLines;  // HUD 用の外周線

    // フィールド（必要なら追加）
    private ModelVisual3D hudModel;       // HUD に表示しているモデル（軸など

    //===============================
    // 公開 API（後方互換）
    //===============================

    /// <summary>
    /// 従来 API 互換：メイン(root.Children/target3D)にシルエットを描く
    /// </summary>
    public void EnableSilhouetteOverlay(Color color, double thickness = 2.0)
    {
        EnsureRenderersInitialized();

        // 生成された Lines を既存フィールド silhouetteLines にも入れて互換維持
        silhouetteLines = _mainSilhouette.Enable(color, thickness, sharpAngleDeg: 30.0);
    }

    /// <summary>
    /// 従来 API 互換：メイン/HUD のシルエットをまとめて無効化
    /// </summary>
    public void DisableSilhouetteOverlay()
    {
        _mainSilhouette?.Disable();
        silhouetteLines = null;
    }

    /// <summary>
    /// HUD 側にシルエットを描く
    /// </summary>
    public void EnableHudSilhouetteOverlay(Color color, double thickness =2.0, double sharpAngleDeg = 30.0)
    {
        EnsureRenderersInitialized();
        hudSilhouetteLines = _hudSilhouette.Enable(color, thickness, sharpAngleDeg);
    }

    /// <summary>
    /// HUD 側のみ無効化
    /// </summary>
    public void DisableHudSilhouetteOverlay()
    {
        _hudSilhouette?.Disable();
        hudSilhouetteLines = null;
    }


    /// <summary>
    /// HUD の対象モデルを設定（HUD に表示しているモデルを渡す）
    /// </summary>
    public void SetHudModel(ModelVisual3D model)
    {
        hudModel = model;
    }


    /// <summary>
    /// モデルの Transform を差し替えた直後など、念のため呼ぶと安全。
    /// （メイン/ HUD のライン Transform を対象に同期）
    /// </summary>
    public void SyncSilhouetteTransforms()
    {
        _mainSilhouette?.SyncTransform();
        _hudSilhouette?.SyncTransform();
    }

    //===============================
    // 内部：レンダラの初期化
    //===============================
    private void EnsureRenderersInitialized()
    {
        if (_mainSilhouette == null && root != null)
        {
            _mainSilhouette = new SilhouetteOverlayRenderer(
                hostChildren: root.Children,
                getTarget: () => target3D,
                // （互換のため）作成された Lines を silhouetteLines に反映
                onCreated: lines => silhouetteLines = lines,
                onRemoved: () => { if (silhouetteLines != null) silhouetteLines = null; }
            );
        }

        if (_hudSilhouette == null)
        {
            _hudSilhouette = new SilhouetteOverlayRenderer(
                hostChildren: hudRoot.Children,
                getTarget: () => hudModel,
                onCreated: lines => hudSilhouetteLines = lines,
                onRemoved: () => { if (hudSilhouetteLines != null) hudSilhouetteLines = null; }
            );
        }
    }

    //=============================================================
    // 内部クラス：シルエット描画レンダラ（root / HUD で使い回す）
    //=============================================================
    private sealed class SilhouetteOverlayRenderer
    {
        private readonly Visual3DCollection _hostChildren;    // 追加先（root.Children / hudRoot.Children）
        private readonly Func<ModelVisual3D> _getTarget;      // 対象（target3D / hudModel）
        private readonly Action<LinesVisual3D> _onCreated;    // Lines 作成時のコールバック（互換用など）
        private readonly Action _onRemoved;                   // Lines 削除時のコールバック
        private LinesVisual3D _lines;

        public bool Enabled { get; private set; }
        public Color Color { get; private set; } = Colors.Black;
        public double Thickness { get; private set; } = 2.0;
        public double SharpAngleDeg { get; private set; } = 30.0;
        public bool AddDepthOffset { get; set; } = false;

        public SilhouetteOverlayRenderer(
            Visual3DCollection hostChildren,
            Func<ModelVisual3D> getTarget,
            Action<LinesVisual3D> onCreated = null,
            Action onRemoved = null)
        {
            _hostChildren = hostChildren ?? throw new ArgumentNullException(nameof(hostChildren));
            _getTarget = getTarget ?? throw new ArgumentNullException(nameof(getTarget));
            _onCreated = onCreated;
            _onRemoved = onRemoved;
        }

        /// <summary>
        /// 有効化して作り直す（返値：現在の LinesVisual3D）
        /// </summary>
        public LinesVisual3D Enable(Color color, double thickness, double sharpAngleDeg = 30.0)
        {
            Enabled = true;
            Color = color;
            Thickness = thickness;
            SharpAngleDeg = sharpAngleDeg;
            Rebuild();
            return _lines;
        }

        public void Disable()
        {
            Enabled = false;
            RemoveLines();
        }

        public void Rebuild()
        {
            if (!Enabled) return;

            var target = _getTarget();
            if (target?.Content == null) { RemoveLines(); return; }

            RemoveLines();

            var points = BuildSilhouettePoints(target.Content, SharpAngleDeg);
            if (points == null || points.Count == 0) return;

            var lines = new LinesVisual3D
            {
                Color = Color,
                Thickness = Thickness,
                Points = points
            };

            // Transform 追従
            if (AddDepthOffset)
            {
                var tg = new Transform3DGroup();
                if (target.Transform != null) tg.Children.Add(target.Transform);
                tg.Children.Add(new TranslateTransform3D(0, 0, 1e-4));
                lines.Transform = tg;
            }
            else
            {
                lines.Transform = target.Transform;
            }

            _hostChildren.Add(lines);
            _lines = lines;
            _onCreated?.Invoke(lines);
        }

        /// <summary>
        /// 対象の Transform が差し替わった場合に呼ぶと、ライン側の Transform を同期します。
        /// </summary>
        public void SyncTransform()
        {
            if (_lines == null) return;
            var target = _getTarget();
            if (target == null) return;

            if (AddDepthOffset)
            {
                var tg = new Transform3DGroup();
                if (target.Transform != null) tg.Children.Add(target.Transform);
                tg.Children.Add(new TranslateTransform3D(0, 0, 1e-4));
                _lines.Transform = tg;
            }
            else
            {
                _lines.Transform = target.Transform;
            }
        }

        private void RemoveLines()
        {
            if (_lines != null)
            {
                _hostChildren.Remove(_lines);
                _lines = null;
                _onRemoved?.Invoke();
            }
        }

        /// <summary>
        /// 既存の RebuildSilhouetteOverlay の中核（境界/シャープエッジ抽出）を関数化
        /// </summary>
        private static Point3DCollection BuildSilhouettePoints(Model3D model, double sharpAngleDeg)
        {
            if (model == null) return null;

            var points = new Point3DCollection();
            double cosThreshold = Math.Cos(sharpAngleDeg * Math.PI / 180.0);

            void Traverse(Model3D m, Matrix3D acc)
            {
                // Transform の累積
                if (m.Transform != null)
                {
                    var tmp = acc;
                    tmp.Append(m.Transform.Value);
                    acc = tmp;
                }

                if (m is Model3DGroup g)
                {
                    foreach (var c in g.Children) Traverse(c, acc);
                    return;
                }
                if (!(m is GeometryModel3D gm)) return;
                if (!(gm.Geometry is MeshGeometry3D mesh)) return;

                var pos = mesh.Positions;
                var idx = mesh.TriangleIndices;
                if (pos == null || idx == null || idx.Count < 3) return;

                // 位置を acc でワールド化
                var tpos = new Point3D[pos.Count];
                for (int i = 0; i < pos.Count; i++)
                    tpos[i] = acc.Transform(pos[i]);

                int triCount = idx.Count / 3;
                var normals = new Vector3D[triCount];

                // 三角面の法線
                for (int t = 0; t < triCount; t++)
                {
                    int i0 = idx[t * 3 + 0];
                    int i1 = idx[t * 3 + 1];
                    int i2 = idx[t * 3 + 2];
                    var p0 = tpos[i0];
                    var p1 = tpos[i1];
                    var p2 = tpos[i2];
                    var n = Vector3D.CrossProduct(p1 - p0, p2 - p0);
                    if (n.LengthSquared > 1e-12) { n.Normalize(); normals[t] = n; }
                    else { normals[t] = new Vector3D(0, 0, 0); }
                }

                // エッジ → 隣接面リスト
                var edges = new Dictionary<(int a, int b), List<int>>(idx.Count);
                void AddEdge(int a, int b, int tri)
                {
                    if (a > b) (a, b) = (b, a);
                    var key = (a, b);
                    if (!edges.TryGetValue(key, out var list))
                    {
                        list = new List<int>(2);
                        edges[key] = list;
                    }
                    list.Add(tri);
                }

                for (int t = 0; t < triCount; t++)
                {
                    int i0 = idx[t * 3 + 0];
                    int i1 = idx[t * 3 + 1];
                    int i2 = idx[t * 3 + 2];
                    AddEdge(i0, i1, t);
                    AddEdge(i1, i2, t);
                    AddEdge(i2, i0, t);
                }

                // 境界エッジ + シャープエッジのみ線にする
                foreach (var kv in edges)
                {
                    int a = kv.Key.a;
                    int b = kv.Key.b;
                    var faces = kv.Value;
                    bool draw = false;

                    if (faces.Count == 1)
                    {
                        // 境界
                        draw = true;
                    }
                    else if (faces.Count == 2)
                    {
                        // シャープ
                        var n0 = normals[faces[0]];
                        var n1 = normals[faces[1]];
                        double dot = Vector3D.DotProduct(n0, n1);
                        if (dot < cosThreshold) draw = true;
                    }
                    if (!draw) continue;

                    points.Add(tpos[a]);
                    points.Add(tpos[b]);
                }
            }

            Traverse(model, Matrix3D.Identity);
            return points;
        }
    }
}
