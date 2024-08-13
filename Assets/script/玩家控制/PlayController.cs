using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの移動とアニメーションを制御するコンポーネント
/// </summary>
public class PlayController : MonoBehaviour
{
    private Rigidbody2D rb; // プレイヤーの Rigidbody2D
    private Animator anim; // プレイヤーのアニメーター

    public float speed; // 移動速度
    private Vector2 movement; // 移動ベクトル

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D を取得
        anim = GetComponent<Animator>(); // アニメーターを取得
    }

    void Update()
    {
        // 水平方向の入力を取得
        movement.x = Input.GetAxisRaw("Horizontal");

        // 入力に応じてプレイヤーの向きを変更
        if (movement.x != 0)
        {
            transform.localScale = new Vector3(movement.x, 1, 1);
        }

        SwitchAnim(); // アニメーションを切り替え
    }

    void FixedUpdate()
    {
        // Rigidbody2D を使用してプレイヤーを移動
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    /// <summary>
    /// プレイヤーの移動アニメーションを切り替える
    /// </summary>
    void SwitchAnim()
    {
        anim.SetFloat("speed", movement.magnitude); // 移動速度に応じてアニメーションを切り替え
    }
}
