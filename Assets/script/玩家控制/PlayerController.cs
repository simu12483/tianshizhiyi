using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; // 移動速度
    private Rigidbody2D playerRigidbody; // プレイヤーの Rigidbody2D
    private Animator animator; // プレイヤーのアニメーター
    private float inputX, inputY; // 入力ベクトル
    private float stopX, stopY; // 停止時の向き

    void Start() 
    {
        playerRigidbody = GetComponent<Rigidbody2D>(); // Rigidbody2D を取得
        animator = GetComponent<Animator>(); // アニメーターを取得
    }

    void Update()
    {
        // 入力を取得
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        // 入力ベクトルを正規化
        Vector2 input = new Vector2(inputX, inputY).normalized;

        // プレイヤーを移動
        playerRigidbody.velocity = input * speed;

        // 入力に応じてアニメーションを設定
        if (input != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            stopX = inputX;
            stopY = inputY;    
        }
        else 
        {
            animator.SetBool("isMoving", false);
        }

        // 停止時の向きをアニメーションに反映
        animator.SetFloat("inputX", stopX);
        animator.SetFloat("inputY", stopY);
    }
}
