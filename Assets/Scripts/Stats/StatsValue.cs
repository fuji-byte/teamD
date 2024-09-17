using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class StatsValue : MonoBehaviour
{
    //保存するため、数値を初期化してはいけない
    //データベースに保存するには[SerializeField]としなくてはいけない
    public static float BestRecord;
    public static int Escape = 0;
    //floatで計算し、後にintに変更
    public static float length;
    //数値取得元GameOver.distance
    public static int Tasks;
    //数値取得元GenerateLevels.TaskCleared;

    //各変数の値の更新情報
    public static void GameClear(float NowRecord)
    //BestRecordの値の更新
    {
        if(NowRecord<BestRecord)
        {
            BestRecord = NowRecord;
        }
    }

    //Escape:クリアした際、obstacle.csにてインクリメント

    public static void LengthUpdate(float NowLength)
    {
        // Debug.Log(NowLength);
        length += NowLength;
        length = (int)length;
    }

    //TaskClearedを再利用
    void Update()
    {
    Tasks = GenerateLevels.TaskCleared;
    }
}
