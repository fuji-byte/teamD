using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LengthText : MonoBehaviour
{
    public TMPro.TMP_Text Length;

    void Start()
    {
        Length.text= StatsValue.length.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // UnityEngine.Debug.Log(StatsValue.BestRecord.ToString());
        Length.text= StatsValue.length.ToString();
    }
}