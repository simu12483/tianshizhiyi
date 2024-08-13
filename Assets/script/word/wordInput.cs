using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの入力を管理するコンポーネント
/// </summary>
public class wordInput : MonoBehaviour
{
    void Update()
    {
        if (wordManger.instance.gameEnd) return;// ゲームが終了した場合は入力を無視する
        
        foreach (char letter in Input.inputString)
        {
            wordManger.instance.TypeLetter(letter);
        }
    }
}
