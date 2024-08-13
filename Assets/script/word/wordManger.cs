using System.Collections;
using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ワードの生成と管理を行うメインクラス
/// </summary>
public class wordManger : MonoBehaviour
{
public static wordManger instance; // シングルトンインスタンス
    public List<Word> words = new List<Word>(); // 単語のリスト
    public wordSpawn wordSpawn; // 単語スポーンの管理コンポーネント
    private bool hasActiveWord;
    private Word activeWord;
    public GameObject failUI; // 失敗時に表示するUI
    public GameObject dialoguePanel; // ダイアログパネル
    public GameObject winIllustration; // 勝利時に表示するイラスト
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
        Word word = new Word(wordGenerate.GetRandomWord(), wordSpawn.SpawnWord().GetComponent<wordDisplay>());
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
            foreach (Word word in words)
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

    public void ShowDialoguePanel()
    {
        Debug.Log("ゲーム終了");
        gameEnd = true;

        // 显示插画
        if (winIllustration != null)
        {
            winIllustration.SetActive(true);
            StartCoroutine(WaitAndShowDialogue());
        }
        else
        {
            Debug.LogError("winIllustrationがインスペクターで設定されていません。");
        }
    }

    private IEnumerator WaitAndShowDialogue()
    {
        
        yield return new WaitForSeconds(5f);

        
        if (winIllustration != null)
        {
            winIllustration.SetActive(false);
        }

        
        if (dialoguePanel != null)
        {
            dialoguePanel.SetActive(true);
        }
        else
        {
            Debug.LogError("dialoguePanelがインスペクターで設定されていません。");
        }
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
}
