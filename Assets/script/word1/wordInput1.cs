using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordGame;

/// <summary>
/// プレイヤーの入力を管理するコンポーネント
/// </summary>
public class wordInput1 : MonoBehaviour
{
    void Update()
    {
        foreach (char letter in Input.inputString)
        {
            WordManager1.instance.TypeLetter(letter);// 入力された文字を処理
        }
    }
}
