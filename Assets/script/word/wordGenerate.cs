using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ランダムなワードを生成するクラス
/// </summary>
public class wordGenerate : MonoBehaviour
{
    private static string[] wordlist = {"kimoi","uzai","darui","busu","saitei"};
    
    /// <summary>
    /// ランダムなワードを取得
    /// </summary>
    /// <returns>ランダムなワード</returns>
    public static string GetRandomWord()
    {
       int randomIndex = Random.Range(0,wordlist.Length);
       string randomWord = wordlist[randomIndex];
       return randomWord; 
    }
}
