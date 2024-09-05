using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoldDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static char a; // モールス信号を格納する変数
    private bool isPointerDown = false; // ポインターが押されているか
    private float holdStartTime; // 長押しの開始時間

    // ポインターが押されたとき
    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        holdStartTime = Time.time; // 長押しの開始時間を記録
    }

    // ポインターが離されたとき
    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;

        if (Time.time - holdStartTime < 0.3f) // 0.3秒未満なら短押し
        {
            a = '.'; // 短押しは . を代入
            MorseSignal.MorseInput(a);
        }
        else // 0.3秒以上なら長押し
        {
            a = '-'; // 長押しは - を代入
            MorseSignal.MorseInput(a);
        }
        
    }

    void Update()
    {
        // 長押し判定（ポインターが押されていて、一定時間経過したら長押しと判定）
        //if (isPointerDown && Time.time - holdStartTime >= 0.5f)
        //{
        //    a = '-'; // 長押しは - を代入
        //    MorseSignal.MorseInput(a);
        //    isPointerDown = false; // 長押し判定後はフラグをリセット
        //}
    }
}