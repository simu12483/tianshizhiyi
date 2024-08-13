using UnityEngine;

/// <summary>
/// ダイアログトリガーを制御するコンポーネント
/// </summary>
public class DialogueTrigger : MonoBehaviour
{
    [Tooltip("ダイアログ表示用のパネル")]
    public GameObject dialoguePanel; // ダイアログパネル

    /// <summary>
    /// プレイヤーがトリガー領域に入ると、ダイアログパネルを表示する
    /// </summary>
    /// <param name="other">トリガーと衝突する他のオブジェクト</param>
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) // プレイヤーのみがダイアログをトリガーできるように確認
        {
            dialoguePanel.SetActive(true);
        }
    }
}

