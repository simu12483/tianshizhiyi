using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ダイアログの開閉を制御するコンポーネント
/// </summary>
public class DialogController : MonoBehaviour
{
    [Tooltip("ダイアログパネル")]
    public GameObject dialogPanel;// ダイアログパネル
    
    /// <summary>
    /// ダイアログを開く
    /// </summary>
    public void OpenDialog()
    {
        dialogPanel.SetActive(true);
    }
    
     /// <summary>
    /// ダイアログを閉じる
    /// </summary>
    public void CloseDialog()
    {
        dialogPanel.SetActive(false);
    }
}
