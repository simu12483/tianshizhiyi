using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ワードから生成された弾丸を管理するコンポーネント
/// </summary>
public class wordBullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5);// 5秒後に弾丸を自動的に破壊
    }

    void Update()
    {
        transform.Translate(Vector3 .up  * Time.deltaTime * 10);// 弾丸を上方向に移動
    }
   
}
