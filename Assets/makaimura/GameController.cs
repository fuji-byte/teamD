using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Animator knightAnimator;
    public Animator skeletonAnimator;
    public Text MKI_gameClearText;
    public Text MKI_gameOverText;
    public Text MKI_clickCountText;
    public float time = 20.0f;
    public Text timeText;
    public int MKI_clickCount = 0;
    public bool MKI_gameFinished = false;

    void Start()
    {
        MKI_gameClearText.gameObject.SetActive(false); // 初期状態で非表示
        MKI_gameOverText.gameObject.SetActive(false); // 初期状態で非表示
    }

    void Update()
    {
        if (time > 0)
        {
            if (Input.GetMouseButtonDown(0)) // 左クリックを検知
            {
                MKI_clickCount++;
                UpdateMKI_clickCountText(); // クリック数を更新
            }
        }

        if (MKI_clickCount >= 70)
        {
            MKI_clickCountText.text = "討伐数：70/70";
            if(MKI_gameFinished == false){
                GameClear();
                MKI_gameFinished = true;
            }
        }

        if (time <= 0)
        {
            //テキストにカウントダウンの表示をする
            timeText.text = "残り時間:0.00";
            if(MKI_gameFinished == false){
                GameOver();
                MKI_gameFinished = true;
            }
        }
        else
        {
            //カウントダウンさせる
            if (MKI_clickCount < 70)
            {
                time -= Time.deltaTime;

                //テキストにカウントダウンの表示をする
                timeText.text = "残り時間:" + time.ToString("f2");
            }
        }
    }

    void UpdateMKI_clickCountText()
    {
        MKI_clickCountText.text = "討伐数：" + MKI_clickCount + "/70";
    }

    void GameClear()
    {
        MKI_gameClearText.gameObject.SetActive(true); // ゲームクリアのメッセージを表示
        //time.timeScale = 0f; // ゲームを停止
        TaskLogic.taskWaiting = true; //タスク待機状態にする
    }

    void GameOver()
    {
        MKI_gameOverText.gameObject.SetActive(true); // ゲームオーバーのメッセージを表示
        //time.timeScale = 0f; // ゲームを停止
        TaskLogic.taskWaiting = true; //タスク待機状態にする
    }
}