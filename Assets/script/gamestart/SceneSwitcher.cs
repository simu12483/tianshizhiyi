using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの切り替えを管理するコンポーネント
/// </summary>
public class SceneSwitcher : MonoBehaviour
{
   /// <summary>
    /// ボタンがクリックされたときに呼び出されるメソッド
    /// </summary>
    /// <param name="sceneIndex">読み込むシーンのインデックス</param>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
