using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ランダムなワードを生成するクラス
/// </summary>
public class wordGenerate1 : MonoBehaviour
{
    
    private static string[] wordList = {"kimoi","uzai","darui","busu","saitei"};
    
    /// <summary>
    /// ランダムなワードを取得
    /// </summary>
    /// <returns>ランダムなワード</returns>
    public static string GetRandomWord()
    {
        int randomIndex = Random.Range(0, wordList.Length);
        return wordList[randomIndex];
    }
}
