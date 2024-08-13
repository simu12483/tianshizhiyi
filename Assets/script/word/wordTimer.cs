using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ワードの出現タイミングを管理するコンポーネント
/// </summary>
public class wordTimer : MonoBehaviour
{
    public wordManger wordManger;
    public float wordDelay = 3.5f;// ワードが出現する間隔
    private float nextWordTime=0f;
    private void Update()
    {
        if (wordManger.gameEnd) return; // ゲームが終了している場合はタイマーを停止
        if (Time.time >= nextWordTime )
        {
            wordManger.AddWord();// 新しいワードを追加
            nextWordTime = Time.time + wordDelay;
            wordDelay *=0.99f;// ワードの出現間隔を徐々に短縮
        }       
    }
    
}
