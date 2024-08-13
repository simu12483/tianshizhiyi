using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ワードオブジェクトをスポーンするコンポーネント
/// </summary>
public class wordSpawn : MonoBehaviour
{
    public GameObject wordPrefab;// ワードのプレハブ
    public Transform wordCanvans;// ワードを配置するキャンバス
    
    /// <summary>
    /// ワードをスポーンするメソッド
    /// </summary>
    /// <returns>スポーンしたワードの表示コンポーネント</returns>
   public wordDisplay SpawnWord()
   {
     Vector3 randomPosition = new Vector3(Random.Range(-25f,25f),18f);
     
     GameObject wordObj = Instantiate(wordPrefab,randomPosition,Quaternion.identity,wordCanvans);
     wordDisplay wordDisplay = wordObj.GetComponent<wordDisplay>();   
     
     return wordDisplay;
     //
   }
}
