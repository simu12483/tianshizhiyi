using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ワードが特定のラインに衝突したかどうかをチェックするコンポーネント
/// </summary>

public class WordCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("FailureLine"))
        {
            Debug.Log("FailureLineとの衝突を検出");
            wordManger.instance.ShowFailPanel(); // 失敗パネルを表示
        }
    }
}
