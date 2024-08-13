using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordGame;

/// <summary>
/// ワードが特定のラインに衝突したかどうかをチェックするコンポーネント
/// </summary>
public class WordCheck1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("FailureLine"))
        {
            Debug.Log("FailureLineとの衝突を検出");
            WordManager1.instance.ShowFailPanel(); // 失敗パネルを表示
         }
    }
}
