using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framerate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
{
    // VSyncCount を Dont Sync に変更
    QualitySettings.vSyncCount = 0;
    // 60fpsを目標に設定
    Application.targetFrameRate = 60;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
