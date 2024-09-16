using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultValue : MonoBehaviour
{
    //タスククリア数をtasksとおく
    private int tasks = GenerateLevels.TaskCleared;

    //Playerが走った距離
    //ゲームクリアしたときの座標
    private float distance1 = GameOver.distance1;
    //クリアしたときの座標
    private float distance2 = Obstacle.distance2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
