using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dameged : MonoBehaviour
{
    private static Image DamageImg;
    void Start()
    {
        DamageImg=GetComponent<Image>();
        DamageImg.color = Color.clear;
    }
    
    void Update()
    {
        DamageImg.color = Color.Lerp(DamageImg.color, Color.clear, Time.deltaTime*0.5f);
    }

    static public void Damaged()
    {
            DamageImg.color = new Color(0.7f, 0, 0, 0.7f);
        
    }
}