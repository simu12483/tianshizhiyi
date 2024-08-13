using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デモン（敵）のロジックを管理するクラス
/// </summary>
public class wordDemoo : MonoBehaviour
{
    public Animator anim;// デモンのアニメーター

    public int heart ; // デモンの初期体力

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);// 弾丸を破壊
            heart -= 1;
            anim.SetTrigger("hurt");
            if (heart <= 0)
            {
                wordManger.instance.ShowDialoguePanel();// ダイアログパネルを表示
            }
        }
    }
}
