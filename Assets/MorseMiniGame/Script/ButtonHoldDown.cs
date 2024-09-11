// using UnityEngine;
// using UnityEngine.EventSystems;

// //public class ButtonHoldDown : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
// public class ButtonHoldDown : MonoBehaviour
// {
//     public static char a; // モールス信号を格納する変数
//     private bool isPointerDown = false; // ポインターが押されているか
//     private float holdStartTime; // 長押しの開始時間

//     // ポインターが押されたとき
//     // public void OnPointerDown(PointerEventData eventData)
//     // {
//     //     isPointerDown = true;
//     //     holdStartTime = Time.time; // 長押しの開始時間を記録
//     // }


//     // // ポインターが離されたとき
//     // public void OnPointerUp(PointerEventData eventData)
//     // {
//     //     isPointerDown = false;

//     //     if (Time.time - holdStartTime < 0.3f) // 0.3秒未満なら短押し
//     //     {
//     //         if(MorseSignal.morseGameFinished == false){
//     //         a = '.'; // 短押しは . を代入
//     //         MorseSignal.MorseInput(a);
//     //         }
//     //     }
//     //     else // 0.3秒以上なら長押し
//     //     {
//     //         if(MorseSignal.morseGameFinished == false){
//     //         a = '-'; // 長押しは - を代入
//     //         MorseSignal.MorseInput(a);
//     //         }
//     //     }
        
//     // }

//     void Update()
//     {
//         if (Input.GetMouseButton(0))
//         {
//             //isPointerDown = true;
//             holdStartTime = Time.time; // 長押しの開始時間を記録
//         }
    
//         //isPointerDown = false;

//         if (Time.time - holdStartTime < 0.3f && Time.time - holdStartTime > 0.0f) // 0.3秒未満なら短押し
//         {
//             if(MorseSignal.morseGameFinished == false){
//             a = '.'; // 短押しは . を代入
//             MorseSignal.MorseInput(a);
//             }
//         }
//         else // 0.3秒以上なら長押し
//         {
//             if(MorseSignal.morseGameFinished == false){
//             a = '-'; // 長押しは - を代入
//             MorseSignal.MorseInput(a);
//             }
//         }

//     }
// }
using UnityEngine;

public class ButtonHoldDown : MonoBehaviour
{
    public static char a; // モールス信号を格納する変数
    private bool isMouseDown = false; // マウスボタンが押されているか
    private float holdStartTime; // 長押しの開始時間

    void Update()
    {
        // マウスボタンが押された瞬間
        if (Input.GetMouseButtonDown(0)) 
        {
            isMouseDown = true;
            holdStartTime = Time.time; 
        }

        // マウスボタンが離された瞬間
        if (Input.GetMouseButtonUp(0)) 
        {
            isMouseDown = false;

            if (Time.time - holdStartTime < 0.3f) // 0.3秒未満なら短押し
            {
                if(MorseSignal.morseGameFinished == false){
                    a = '.'; 
                    MorseSignal.MorseInput(a);
                }
            }
            else // 0.3秒以上なら長押し
            {
                if(MorseSignal.morseGameFinished == false){
                    a = '-'; 
                    MorseSignal.MorseInput(a);
                }
            }
        }
    }
}