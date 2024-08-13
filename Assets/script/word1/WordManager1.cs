using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WordGame; // 引用 WordGame 命名空间

namespace WordGame
{
    public class WordManager1 : MonoBehaviour
    {
       public static WordManager1 instance; // シングルトンインスタンス
        public List<Word1> words = new List<Word1>(); // 単語のリスト
        public wordSpawn1 wordSpawn; // 単語スポーンの管理コンポーネント
        private bool hasActiveWord;
        private Word1 activeWord;
        public GameObject failUI; // 失敗時に表示するUI
        public GameObject winUI; // 勝利時に表示するUI
        public bool gameEnd = false; // ゲーム終了フラグ
        public Transform bossTr; // ボスのTransform

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            AddWord();
        }

        public void AddWord()
        {
            Word1 word = new Word1(wordGenerate1.GetRandomWord(), wordSpawn.SpawnWord().GetComponent<WordDisplay1>());
            Debug.Log(word.word);
            words.Add(word);
        }

        public void TypeLetter(char letter)
        {
            if (hasActiveWord)
            {
                if (activeWord.GetNextLetter() == letter)
                {
                    activeWord.TypeLetter();
                    if (activeWord.WordTyped(bossTr))
                    {
                        CompleteWord();
                    }
                }
            }
            else
            {
                foreach (Word1 word in words)
                {
                    if (word.GetNextLetter() == letter)
                    {
                        activeWord = word;
                        hasActiveWord = true;
                        word.TypeLetter();
                        if (activeWord.WordTyped(bossTr))
                        {
                            CompleteWord();
                        }
                        break;
                    }
                }
            }
        }

        private void CompleteWord()
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            AddWord();
        }

        public void ShowFailPanel()
        {
            if (!gameEnd)
            {
                Debug.Log("失敗");
                gameEnd = true;
                if (failUI != null)
                {
                    failUI.SetActive(true);
                }
                else
                {
                    Debug.LogError("failUIがインスペクターで設定されていません。");
                }
            }
        }

        public void ShowWinPanel()
        {
            if (!gameEnd)
            {
                Debug.Log("勝利");
                gameEnd = true;
                if (winUI != null)
                {
                    winUI.SetActive(true);
                }
                else
                {
                    Debug.LogError("winUIがインスペクターで設定されていません。");
                }
            }
        }
    }
}
