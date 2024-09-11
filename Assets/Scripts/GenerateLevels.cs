using System;
using System.Collections;
using System.Collections.Generic;
// using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Analytics;

public class GenerateLevels : MonoBehaviour
{
    public GameObject[] level;
    public static int zPos = -150;
    //zの軸の座標
    public static bool creatingLevel = false;

    public static int TaskCleared = 0;
    public static int lvlNum;

    public static int RoadLevel = 0;
    void Start()
    {
        for(int i=0;i<=7;i++)
        {
            Instantiate(level[0], new Vector3(0, 0, zPos), Quaternion.identity);
            zPos += 50;
            //8times
        }
    }

    void LevelOperator()
    {
        // Debug.Log(Time.time-5);
        for(int i=0;i<8;i++)
        {
        //難易度設定の条件
        if(TaskCleared>=(3*i)&&(Time.time-5)>=30*i)
        {
            RoadLevel = (i+1);
            // Debug.Log("クリア"+TaskCleared+"回");
        }
        else
        {
            //elseにて難易度が確定する
            if(RoadLevel==i)
            {
                lvlNum = UnityEngine.Random.Range(RoadLevel, RoadLevel+3);
                // Debug.Log("今の難易度は"+RoadLevel+"です");
                break;//falseになったら終了
            }
        }
        }
        
    }

    void Goal()
    //LevelOperatorに統合できる。だが断る
    {
        if(RoadLevel==8)
        {
            Instantiate(level[10], new Vector3(0, 0, zPos), Quaternion.identity);
        }
    }
    void Update()
    {
        if (creatingLevel)
        {
            LevelOperator();
            Goal();
            Instantiate(level[lvlNum], new Vector3(0, 0, zPos), Quaternion.identity);
            if(lvlNum==9)
            {
                zPos += 200;
            }
            else
            {
                zPos += 50;
            }
            creatingLevel = false;
        }
    }
}