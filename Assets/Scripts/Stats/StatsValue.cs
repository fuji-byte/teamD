using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class StatsValue : MonoBehaviour
{
    public static float BestRecord;
    public static int Escape;
    //floatで計算し、後にintに変更
    public static float length;
    //数値取得元GameOver.distance
    public static int Tasks;
    //数値取得元GenerateLevels.TaskClearedと同じ;

    void Start()
    {
        //各スコアのロード
        BestRecord = PlayerPrefs.GetFloat ("BestRecord", 0);
        Escape = PlayerPrefs.GetInt ("Escape", 0);
        length = PlayerPrefs.GetFloat ("length", 0);
        Tasks = PlayerPrefs.GetInt ("Tasks", 0);
    }

    void Reset()
    {
        //データのリセット
        PlayerPrefs.DeleteAll();
    }

    //各変数の値の更新情報

//BestRecord: obstacle.csにて値更新
    public static void GameClear(float NowRecord)
    {
        if(NowRecord<BestRecord)
        {
            BestRecord = NowRecord;
            PlayerPrefs.SetFloat("BestRecord",BestRecord);
            PlayerPrefs.Save ();
        }
    }

//Escape:クリアした際、obstacle.csにてインクリメント
    public static void Escapes()
    {
        Escape ++;
        PlayerPrefs.SetInt("Escape",Escape);
        PlayerPrefs.Save ();
    }

//length: GameOver.cs又はobstacle.csにて値更新
    public static void LengthUpdate(float NowLength)
    {
        // Debug.Log(NowLength);
        length += NowLength;
        length = (int)length;
        PlayerPrefs.SetFloat("length",length);
        PlayerPrefs.Save ();
    }

//Tasks: TaskClearedと同様
    public static void TaskC()
    {
        Tasks ++;
        PlayerPrefs.SetInt("Tasks",Tasks);
        PlayerPrefs.Save ();
    }
    
}
