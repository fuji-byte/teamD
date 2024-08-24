using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

public class Obstacle : MonoBehaviour
{
    //オブジェクトが衝突した際に実行
    private void OnCollisionEnter(Collision collision)
    {
        //衝突した相手のタグがPlayerの場合
        if (collision.gameObject.CompareTag("Player"))
        {
            //(仮置き)自身のタグがPlayerの場合
            if (this.gameObject.tag == "Player")
            {
                //ゲームクリア処理を実行
                GameClear.GameClearShowPanel();
            }
            else
            {
                //ゲームオーバー処理を実行
                GameOver.GameOverShowPanel();
                //自身を削除
                Destroy(this.gameObject);
            }
        }
    }
}

