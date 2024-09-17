using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
public class BestScoreTitle : MonoBehaviour
{
    public TMPro.TMP_Text TitleBestScore;

    public float TitleBest=0;
    void Awake()
    {
        TitleBest = PlayerPrefs.GetFloat ("BestRecord", 0);
        TitleBestScore.text= TitleBest+"m";
    }
}
