using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro名前空間のインポート
using UnityEngine.UI;
using System.IO; // ファイル入出力用の名前空間

/// <summary>
/// ダイアログシステムの第5バージョン
/// </summary>
public class DialogueSystem5 : MonoBehaviour
{
    [Header("UIコンポーネント")]
    public TextMeshProUGUI textLabel;  // ダイアログテキストのUIコンポーネント
    public TextMeshProUGUI nameLabel;  // 話者の名前のUIコンポーネント
    public Image faceImage;  // 話者の顔画像のUIコンポーネント
    public Button yesButton;  // ダイアログ終了時のボタン
    
    [Header("テキストコンポーネント")]
    public TextAsset textFile;  // ダイアログ内容を含むテキストファイル
    public int index;  // 現在のダイアログ行のインデックス
    private List<string> textList = new List<string>();  // ダイアログ内容を保存するリスト
   
    [Header("顔画像")]
    public Sprite protagonistFace;  // 主役の顔画像
    public Sprite anotherAngelFace;  // もう一人の天使の顔画像

   [Header("設定")]
    public float textSpeed = 0.05f;  // テキスト表示速度

    private Dictionary<string, Sprite> faceImages;  // 名前と顔画像の辞書
    private Coroutine displayCoroutine;  // ダイアログ表示を管理するコルーチン


    void Start()
    {
        // 名前と顔画像を関連付ける辞書を初期化
        faceImages = new Dictionary<string, Sprite>
        {
            { "主役", protagonistFace },
            { "もう一人の天使", anotherAngelFace }
        };

        GetTextFromFile(textFile); // ファイルからダイアログ内容を読み込む
        index = 0;

          // ボタンの初期状態を非表示に設定
        yesButton.gameObject.SetActive(false);

        // yesButtonにクリックイベントを追加
        yesButton.onClick.AddListener(OnYesButtonClicked);

        // ダイアログ表示を開始
        if (textList.Count > 0)
        {
            DisplayDialogue();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine);  // 現在のコルーチンを停止
                CompleteDialogue();  // ダイアログを即座に表示
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

            /// 名前に基づいて顔画像を表示
            if (faceImages.ContainsKey(name))
            {
                faceImage.sprite = faceImages[name];
            }
            else
            {
                faceImage.sprite = null;  
            }

            displayCoroutine = StartCoroutine(SetTextUI(dialogue));
        }
        else
        {
            nameLabel.text = "";  // 名前がない場合、名前ラベルをクリア
            faceImage.sprite = null;  // 顔画像をクリア
            displayCoroutine = StartCoroutine(SetTextUI(line));  // テキストを直接表示
        }
    }

    private IEnumerator SetTextUI(string dialogue)
    {
        textLabel.text = ""; // 前回のテキストをクリア
        yesButton.gameObject.SetActive(false); // ボタンを非表示

        foreach (char letter in dialogue.ToCharArray())
        {
            textLabel.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        displayCoroutine = null;  // ダイアログ表示完了後、コルーチン変数をリセット

        if (index == textList.Count - 1)
        {
            yesButton.gameObject.SetActive(true);
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
            yesButton.gameObject.SetActive(true);
        }
    }

    private void EndDialogue()
    {
        textLabel.text = "";  // ダイアログテキストをクリア
        nameLabel.text = "";  // 名前ラベルをクリア
        faceImage.sprite = null;  // 顔画像をクリア
        yesButton.gameObject.SetActive(true);
        Debug.Log("ダイアログが終了しました");
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
    
    /// <summary>
    /// ダイアログをテキストファイルにエクスポートする
    /// </summary>
     private void ExportDialogue()
    {
        string filePath = Application.dataPath + "/ExportedDialogue.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var line in textList)
            {
                writer.WriteLine(line);
            }
        }
        Debug.Log("ダイアログ内容がエクスポートされました: " + filePath);
    }

    public void OnYesButtonClicked()
    {
        Debug.Log("はいボタンがクリックされました");
        ExportDialogue();  // ダイアログ内容をエクスポート
    }
}
