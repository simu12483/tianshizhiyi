using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WordGame
{
    /// <summary>
    /// デモン（敵）のロジックを管理するクラス
    /// </summary>
    public class wordDemoo1 : MonoBehaviour
    {
       public Animator anim; // デモンのアニメーター
        public int heart = 3; // デモンの初期体力


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);// 弾丸を破壊
                heart -= 1;
                anim.SetTrigger("hurt");
                if (heart <= 0)
                {
                    WordManager1.instance.ShowWinPanel();  // 勝利パネルを表示
                }
            }
        }
    }
}
