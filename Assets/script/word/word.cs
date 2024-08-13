using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

/// <summary>
/// 単語のロジックを管理するクラス
/// </summary>
public class Word
{
 public string word;
 private int typeIndex;
 wordDisplay display;

 public Word(string _word,wordDisplay _display)
 {
     word=_word;
     typeIndex=0;
     display=_display;
     display.SetWord(word);
 }
 public char GetNextLetter()
 {
     return word[typeIndex];
 }
 public void TypeLetter()
 {
     typeIndex++;
     display.RemoveLetter();
 }
 public bool WordTyped(Transform boss)
 {
     bool WordTyped = (typeIndex >= word.Length);
     if(WordTyped)
     {
        display.RemoveWord(boss);
     }
     return WordTyped;

 }
}