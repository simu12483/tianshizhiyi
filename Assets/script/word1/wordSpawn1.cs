using UnityEngine;

namespace WordGame
{
    /// <summary>
    /// ワードオブジェクトをスポーンするコンポーネント
    /// </summary>
    public class wordSpawn1 : MonoBehaviour
    {
        public GameObject wordPrefab;// ワードのプレハブ
        public Transform wordCanvas;// ワードを配置するキャンバス
        
        /// <summary>
        /// ワードをスポーンするメソッド
        /// </summary>
        /// <returns>スポーンしたワードの表示コンポーネント</returns>
        public WordDisplay1 SpawnWord()
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-25f, 25f), 18f, 0); // 使用固定高さ18f
            GameObject wordObj = Instantiate(wordPrefab, spawnPosition, Quaternion.identity, wordCanvas);
            WordDisplay1 wordDisplay = wordObj.GetComponent<WordDisplay1>();

            return wordDisplay;
        }
    }
}
