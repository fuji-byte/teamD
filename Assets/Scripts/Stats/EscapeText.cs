using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EscapeText : MonoBehaviour
{
    public TMPro.TMP_Text Escape;

    void Start()
    {
        Escape.text= StatsValue.Escape.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // UnityEngine.Debug.Log(StatsValue.BestRecord.ToString());
        Escape.text= StatsValue.Escape.ToString();
    }
}
