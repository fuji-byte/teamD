using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TaskText : MonoBehaviour
{
    public TMPro.TMP_Text Task;

    void Start()
    {
        Task.text= StatsValue.Tasks.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // UnityEngine.Debug.Log(StatsValue.BestRecord.ToString());
        Task.text= StatsValue.Tasks.ToString();
    }
}
