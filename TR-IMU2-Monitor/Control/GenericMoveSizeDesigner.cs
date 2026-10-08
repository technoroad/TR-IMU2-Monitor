using System.Windows.Forms.Design;


/// <summary>
/// デザイナ上で移動のみ許可するかどうかを定義するインターフェイス。
/// このインターフェイスを実装したコントロールは、デザイナでサイズ変更のオンオフが切り替えられます。
/// </summary>
public interface IDesignerMovable
{
    /// <summary>
    /// デザイナ上で移動のみ許可するかどうかを示す値。
    /// true の場合、サイズ変更は不可で移動のみ可能となります。
    /// </summary>
    bool DesignerMovable { get; }
}

/// <summary>
/// コントロールのデザイン時の選択ルールを制御する汎用デザイナクラス。
/// IDesignerMovable インターフェイスを実装したコントロールは移動のみ許可し、
/// それ以外はサイズ変更を含むすべての操作を許可します。
/// </summary>
public class GenericMoveSizeDesigner : ControlDesigner
{
    /// <summary>
    /// デザイナ上での選択ルールを取得します。
    /// IDesignerMovable を実装し、DesignerMovable が true の場合は移動のみ許可します。
    /// それ以外の場合はサイズ変更を含むすべての操作を許可します。
    /// </summary>
    public override SelectionRules SelectionRules
    {
        get
        {
            var ctrl = Control;

            // インターフェイスによる判定（どのコントロールでも適用可能）
            if (ctrl is IDesignerMovable movable && movable.DesignerMovable)
            {
                // 移動のみ許可（必要なら Visible/Locked 等を足す）
                return SelectionRules.Moveable;
            }

            // 既定はサイズ変更許可
            return SelectionRules.AllSizeable;
        }
    }
}
