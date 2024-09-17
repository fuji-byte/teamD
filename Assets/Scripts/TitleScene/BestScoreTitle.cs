using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using TMPro;
public class BestScoreTitle : MonoBehaviour
{
    public TMPro.TMP_Text TitleBestScore;
    void Start()
    {
        TitleBestScore.text= (StatsValue.BestRecord.ToString()+"m");
    }
}
