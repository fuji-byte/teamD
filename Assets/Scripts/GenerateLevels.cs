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
            Instantiate(level[9], new Vector3(0, 0, zPos), Quaternion.identity);
            zPos += 200;
            //8times
        }
    }

    void LevelOperator()
    {
        RoadLevel = Random.Range(0, 10);

        RoadLevel = 1;
        // if()
        RoadLevel = 2;
        switch (RoadLevel)
        {
            case 1:
            break;

            case 2:
            break;

            case 3:
            break;

            case 4:
            break;

            case 5:
            break;

        }
    }
    void Update()
    {
        if (creatingLevel)
        {
            creatingLevel = false;
            lvlNum = Random.Range(0, 10); // 0, 1, 2, 3,...,9
            Instantiate(level[lvlNum], new Vector3(0, 0, zPos), Quaternion.identity);
            if(lvlNum==9)
            {
                zPos += 200;
            }
            else
            {
                zPos += 50;
            }
            
        }
    }
}