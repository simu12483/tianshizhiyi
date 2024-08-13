using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionWithUI : MonoBehaviour
{
    public Animator animator;
    public GameObject typewriterText;
    public GameObject illustration;

    private string nextScene;

    // トランジションを開始するメソッド
    public void TransitionToScene(string sceneName)
    {
        nextScene = sceneName;
        animator.SetTrigger("StartTransition");
        ShowTypewriterText();
    }

    // タイプライターエフェクトを表示するメソッド
    void ShowTypewriterText()
    {
        typewriterText.SetActive(true);
        illustration.SetActive(true);
    }

    // トランジションアニメーションの最後に呼ばれるメソッド
    public void OnTransitionComplete()
    {
        SceneManager.LoadScene(nextScene);
    }
}
