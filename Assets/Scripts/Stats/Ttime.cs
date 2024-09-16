using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ttime : MonoBehaviour
{
    public TMPro.TMP_Text Ttimes;

    void Update()
    {
        if(StatsValue.Tasks>2)
        {
            Ttimes.text= "Times";
        }
        else
        {
            Ttimes.text= "Time";
        }
    }
}