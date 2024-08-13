using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordGame;

/// <summary>
/// ワードの出現タイミングを管理するコンポーネント
/// </summary>
public class wordTimer1 : MonoBehaviour
{
    public float wordDelay = 1.5f;// ワードが出現する間隔
    private float nextWordTime = 0f;

    void Update()
    {
        if (Time.time >= nextWordTime)
        {
            WordManager1.instance.AddWord();// 新しいワードを追加
            nextWordTime = Time.time + wordDelay;
        }
    }
}
