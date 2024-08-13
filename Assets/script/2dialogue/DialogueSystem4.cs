using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // 导入TextMeshPro命名空间
using UnityEngine.UI;

/// <summary>
/// ダイアログシステムの第4バージョン
/// </summary>
public class DialogueSystem4 : MonoBehaviour
{
   [Header("UIコンポーネント")]
    public TextMeshProUGUI textLabel; // ダイアログテキスト
    public TextMeshProUGUI nameLabel; // 話者の名前
    public Image faceImage; // 話者の顔画像
    public Button yesButton; // 「はい」ボタン
    public Button noButton; // 「いいえ」ボタン

    [Header("テキストコンポーネント")]
    public TextAsset textFile; // ダイアログテキストファイル
    public int index; // 現在のテキストインデックス
    private List<string> textList = new List<string>(); // ダイアログテキストのリスト

    [Header("顔画像")]
    public Sprite protagonistFace; // 主役の顔画像
    public Sprite demonFace; // 悪魔の顔画像

    [Header("設定")]
    public float textSpeed = 0.05f; // テキスト表示速度

    private Dictionary<string, Sprite> faceImages; // 名前と顔画像の辞書
    private Coroutine displayCoroutine; // テキスト表示コルーチン

    void Start()
    {
        // 名前と顔画像を関連付ける辞書を初期化
        faceImages = new Dictionary<string, Sprite>
        {
            { "主役", protagonistFace },
            { "悪魔", demonFace },
            // さらに名前と画像の対応関係を追加できます
        };

        GetTextFromFile(textFile);// ファイルからテキストを読み込む
        index = 0;
        if (textList.Count > 0)
        {
            DisplayDialogue(); // 初回のダイアログを表示
        }

        // ボタンの初期状態を非表示に設定
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine); // 現在のコルーチンを停止
                CompleteDialogue(); // ダイアログを即座に表示
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
        // 各テキスト行のフォーマットは "名前: ダイアログ内容" を仮定
        var line = textList[index];
        var splitLine = line.Split(':');
        if (splitLine.Length == 2)
        {
            var name = splitLine[0].Trim();
            var dialogue = splitLine[1].Trim();
            nameLabel.text = name;

            // 顔画像を更新
            if (faceImages.ContainsKey(name))
            {
                faceImage.sprite = faceImages[name];
            }
            else
            {
                faceImage.sprite = null; // 如果没有匹配的图片，清空头像
            }

            // ダイアログを一文字ずつ表示するコルーチンを開始
            displayCoroutine = StartCoroutine(SetTextUI(dialogue));
        }
        else
        {
            nameLabel.text = ""; // 名前がない場合、名前ラベルをクリア
            displayCoroutine = StartCoroutine(SetTextUI(line)); // テキストを直接表示
        }
    }

    private IEnumerator SetTextUI(string dialogue)
    {
         textLabel.text = ""; // 前回のテキストをクリア
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);

        foreach (char letter in dialogue.ToCharArray())
        {
            textLabel.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        displayCoroutine = null; // ダイアログ表示が完了した後、コルーチン変数をリセット

        // 最後のダイアログの場合、ボタンを表示
        if (index == textList.Count - 1)
        {
            ShowButtons();
        }
    }

    private void CompleteDialogue()
    {
        var line = textList[index];
        var splitLine = line.Split(':');
        if (splitLine.Length == 2)
        {
            textLabel.text = splitLine[1].Trim();
        }
        else
        {
            textLabel.text = line;
        }

        if (index == textList.Count - 1)
        {
            ShowButtons();
        }
    }

    private void EndDialogue()
    {
        textLabel.text = ""; // ダイアログテキストをクリア
        nameLabel.text = ""; // 名前ラベルをクリア
        faceImage.sprite = null; // 顔画像をクリア
        ShowButtons();
        Debug.Log("ダイアログが終了しました");
    }

    private void ShowButtons()
    {
        Debug.Log("ボタンを表示");
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
    }

    private void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');
        foreach (var line in lineData)
        {
            textList.Add(line.Trim());
        }
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
