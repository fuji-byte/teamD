using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CountdownGameController : MonoBehaviour
{
    public Text readyText;
    public Text timerText;

    private float startTime;
    private float remainingTime;
    private bool isGameStarted = false;

    private bool timerStopped = false;

    void Start()
    {
        timerStopped= false;
        startTime = Time.time + 1f; // 1秒後にゲーム開始
        remainingTime = Random.Range(8f, 12f); // 8〜12秒の間でランダムに設定
        timerText.text = "";
        readyText.text = "Ready";
        isGameStarted=false;//変更点#1
    }

    void Update()
    {
        if (!isGameStarted)
        {
            if (Time.time >= startTime)
            {
                isGameStarted = true;
                readyText.text = "Go!";
            }
        }
        else
        {
            if(timerStopped== false)remainingTime -= Time.deltaTime;
            if (remainingTime <= 0f)
            {
                // ゲームオーバー処理
                timerText.text = "Time Up!";
                readyText.text = "Failed...";
            }
            else if (remainingTime <= 5f)
            {
                if(timerStopped==false)timerText.text = "";
            }
            else
            {
                timerText.text = remainingTime.ToString("F2"); // 小数点以下2桁まで表示
            }
        }

        if (Input.GetMouseButtonDown(0)&&isGameStarted)//変更点#2
        {
            timerStopped=true;

            if (isGameStarted)
            {
                if (remainingTime <= 1f)
                {
                    timerText.text = remainingTime.ToString("F2");
                    readyText.text = "Clear!";
                }
                else
                {
                    timerText.text = remainingTime.ToString("F2");
                    readyText.text = "Failed...";
                }
            }
        }
    }
}