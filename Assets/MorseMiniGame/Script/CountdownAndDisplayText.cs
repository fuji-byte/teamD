using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownAndDisplayText : MonoBehaviour
{
    public Text countdownText;
    public Text displayText;
    public float displayDuration = 0.5f; // 表示時間
    public float readyDuration = 1f; // Ready表示時間
    public float gameDuration = 10f; // ゲーム時間
    private string questionyou="";

    private string[] morseCodes = { "...---...", ".-..-.", "--.--.-.", "..--.--", "-.-..-", "-..--.---", "----..-.-." };

    void Start()
    {
        MorseSignal.morseGameFinished = false;

        if(TaskLogic.rdm == 2){
            StartCoroutine(StartCountdown());
        }
    }

    IEnumerator StartCountdown()
    {
        countdownText.text = "Ready";
        yield return new WaitForSeconds(readyDuration);

        countdownText.text = "GO!";
        // モールス信号をランダムに選択して表示
        displayText.text = morseCodes[Random.Range(0, morseCodes.Length-1)];
        questionyou=displayText.text;

        yield return new WaitForSeconds(displayDuration);
        displayText.text = "";
        MorseSignal.question=questionyou;

        // 15秒のカウントダウン開始
        float remainingTime = gameDuration;
        while (remainingTime > 0)
        {
            countdownText.text = remainingTime.ToString("F2"); // 小数点以下2桁まで表示
            yield return new WaitForSeconds(0.01f); // 0.01秒ごとに更新
            remainingTime -= 0.01f;
        }

        // ゲームオーバー表示
        if(TaskLogic.rdm == 2){
            if(MorseSignal.morseGameFinished == false){
                MorseSignal.morseGameFinished = true;
                TaskLogic.taskWaiting = true;
                CircleHPManager.damageHP(50);
                countdownText.text = "GameOver";
            }
        }
        
    }
}