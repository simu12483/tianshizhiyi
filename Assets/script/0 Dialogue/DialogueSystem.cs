using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro名前空間のインポート
using UnityEngine.UI;

/// <summary>
/// ダイアログシステムのコアクラス
/// </summary>
public class DialogueSystem : MonoBehaviour
{
    [Header("UIコンポーネント")]
    public TextMeshProUGUI textLabel; // ダイアログ内容テキスト
    public TextMeshProUGUI nameLabel; // 話者の名前テキスト
    public Image faceImage; // 話者の顔画像
    public Button yesButton; // 「はい」ボタン
    public Button noButton; // 「いいえ」ボタン

    [Header("テキストコンポーネント")]
    public TextAsset textFile; // ダイアログテキストファイル
    private int index; // 現在のダイアログのインデックス
    private List<string> textList = new List<string>(); // ダイアログ内容のリスト

    [Header("顔画像")]
    public Sprite unknownFace; // 未知のキャラクターの顔画像
    public Sprite protagonistFace; // 主人公の顔画像

    [Header("設定")]
    public float textSpeed = 0.05f; // テキスト表示速度

    private Dictionary<string, Sprite> faceImages; // 名前と顔画像のマッピング辞書
    private Coroutine displayCoroutine; // テキストを一文字ずつ表示するコルーチン

    void Start()
    {
        // 名前と顔画像のマッピング辞書を初期化
        faceImages = new Dictionary<string, Sprite>
        {
            { "？？？", unknownFace },
            { "主役", protagonistFace }
            // ここでさらに名前と対応する画像を追加できます
        };

        LoadTextFromFile(textFile);
        index = 0;
        if (textList.Count > 0)
        {
            DisplayDialogue(); // 初期ダイアログを表示
        }

        // ボタンを非表示にする
        SetButtonsActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine); // 現在のコルーチンを停止する
                CompleteDialogue(); // 完全なダイアログを即座に表示
                displayCoroutine = null;
                return;
            }

            index++;
            if (index < textList.Count)
            {
                DisplayDialogue();
            }
            else
            {
                EndDialogue();
            }
        }
    }

    private void DisplayDialogue()
    {
        var line = textList[index];
        var splitLine = line.Split(':');
        if (splitLine.Length == 2)
        {
            var name = splitLine[0].Trim();
            var dialogue = splitLine[1].Trim();
            nameLabel.text = name;

            // 顔画像を更新する
            faceImage.sprite = faceImages.ContainsKey(name) ? faceImages[name] : null;

            // ダイアログを一文字ずつ表示する
            displayCoroutine = StartCoroutine(TypeDialogue(dialogue));
        }
        else
        {
            nameLabel.text = ""; // 名前がない場合、名前ラベルをクリア
            displayCoroutine = StartCoroutine(TypeDialogue(line)); // テキストを直接表示
        }
    }

    private IEnumerator TypeDialogue(string dialogue)
    {
        textLabel.text = "";
        SetButtonsActive(false);

        foreach (char letter in dialogue.ToCharArray())
        {
            textLabel.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        displayCoroutine = null; // ダイアログ表示完了後にコルーチン変数をリセット

        // 最後のダイアログの場合、ボタンを表示する
        if (index == textList.Count - 1)
        {
            SetButtonsActive(true);
        }
    }

    private void CompleteDialogue()
    {
        var line = textList[index];
        var splitLine = line.Split(':');
        textLabel.text = splitLine.Length == 2 ? splitLine[1].Trim() : line;

        if (index == textList.Count - 1)
        {
            SetButtonsActive(true);
        }
    }

    private void EndDialogue()
    {
        textLabel.text = ""; // ダイアログテキストをクリア
        nameLabel.text = ""; // 名前ラベルをクリア
        faceImage.sprite = null; // 顔画像をクリア
        SetButtonsActive(true); // ボタンを表示する
        Debug.Log("ダイアログが終了しました");
    }

    private void LoadTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lines = file.text.Split('\n');
        foreach (var line in lines)
        {
            textList.Add(line.Trim());
        }
    }

    // ボタンの表示状態を設定
    private void SetButtonsActive(bool isActive)
    {
        yesButton.gameObject.SetActive(isActive);
        noButton.gameObject.SetActive(isActive);
    }

    // ボタンクリックイベントの処理
    public void OnYesButtonClicked()
    {
        Debug.Log("はいボタンがクリックされました");
        // 処理ロジックをここに追加
    }

    public void OnNoButtonClicked()
    {
        Debug.Log("いいえボタンがクリックされました");
        // 処理ロジックをここに追加
    }
}
