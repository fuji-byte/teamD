using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Etime : MonoBehaviour
{
    public TMPro.TMP_Text Etimes;

    void Update()
    {
        if(StatsValue.Escape>2)
        {
            Etimes.text= "Times";
        }
        else
        {
            Etimes.text= "Time";
        }
    }
}
