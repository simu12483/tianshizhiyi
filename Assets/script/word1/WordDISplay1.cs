using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace WordGame
{
     /// <summary>
    /// 単語の表示と挙動を管理するコンポーネント
    /// </summary>
    public class WordDisplay1 : MonoBehaviour
    {
        public wordBullet1 bulletPre; // 弾丸のプレハブ
        public TextMeshProUGUI text; // テキスト表示コンポーネント
        public float fallspeed = 2f; // 落下速度

        public void SetWord(string word)
        {
            text.text = word;
            BoxCollider2D b = gameObject.AddComponent<BoxCollider2D>();
            RectTransform rect = GetComponent<RectTransform>();
            b.size = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y);
        }

        public void RemoveLetter()
        {
            text.text = text.text.Remove(0, 1);
            text.color = Color.red;
        }

        public void RemoveWord(Transform boss)
        {
            Vector2 dir = boss.position - transform.position;
            wordBullet1 bullet = Instantiate(bulletPre, transform.position, Quaternion.identity);
            bullet.transform.up = dir.normalized;

            Destroy(gameObject);
        }

        private void Update()
        {
            if (WordManager1.instance.gameEnd) return; // ゲーム終了時は動作を停止
            transform.Translate(0f, -fallspeed * Time.deltaTime, 0f); // 単語を落下させる
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
               if (other.CompareTag("FailureLine"))
            {
                Debug.Log("FailureLineに衝突");
                WordManager1.instance.ShowFailPanel(); // 失敗パネルを表示
                Destroy(gameObject);
            }
        }
    }
}
