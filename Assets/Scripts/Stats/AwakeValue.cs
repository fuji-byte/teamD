using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AwakeValue : MonoBehaviour
{
    public TMPro.TMP_Text BestRecord;
    public TMPro.TMP_Text Escape;
    public TMPro.TMP_Text Etimes;
    public TMPro.TMP_Text Length;
    public TMPro.TMP_Text Task;
    public TMPro.TMP_Text Ttimes;

    void Awake()
    {
        BestRecord.text= StatsValue.BestRecord.ToString();
        Escape.text= StatsValue.Escape.ToString();
        Length.text = StatsValue.length.ToString();
        Task.text= StatsValue.Tasks.ToString();
        if(StatsValue.Tasks>=2)
        {
            Ttimes.text= "Times";
        }
        else
        {
            Ttimes.text= "Time";
        }
        if(StatsValue.Escape>=2)
        {
            Etimes.text= "Times";
        }
        else
        {
            Etimes.text= "Time";
        }
    }
}
