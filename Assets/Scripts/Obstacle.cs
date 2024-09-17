using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using Newtonsoft.Json;

public class Obstacle : MonoBehaviour
{

    private static Rigidbody Playerrigid;
    public static float distance2;
    //オブジェクトが衝突した際に実行
    private void OnCollisionEnter(Collision collision)
    {
        //衝突した相手のタグがPlayerの場合
        if (collision.gameObject.CompareTag("Player"))
        {
            //自身のタグがClearの場合
            if (this.gameObject.tag == "Clear")
            {
                Playerrigid = GameObject.Find("Player").GetComponent<Rigidbody>();
                //ゲームクリア処理を実行
                GameClear.GameClearShowPanel();
                StatsValue.Escape ++;
                //ゲームクリア時のPlayerのポジションを取得
                distance2 = Mathf.Floor(Playerrigid.position.z/5);
                //PlayerのポジションをStatsValueに渡す
                StatsValue.GameClear(distance2);
                StatsValue.LengthUpdate(distance2);
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

