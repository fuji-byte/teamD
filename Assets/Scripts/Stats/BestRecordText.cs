using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
public class BestRecordText : MonoBehaviour
{
    public TMPro.TMP_Text BestRecord;

    // [SerializeField]
    // Start is called before the first frame update
    //スコアの計算式
    void Start()
    {	
        BestRecord.text= StatsValue.BestRecord.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // UnityEngine.Debug.Log(StatsValue.BestRecord.ToString());
        BestRecord.text= StatsValue.BestRecord.ToString();
    }
}
