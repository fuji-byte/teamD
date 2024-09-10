using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManagerFixed : MonoBehaviour
{
    int maxHP = 100;
    public static int currentHp;
    public Slider HPbar;
    float hpTimer;
    bool rungameFinished;

    void Start()
    {
        // HPbar = GameObject.Find("HPbar").GetComponent<Slider>();

        HPbar.value = 100;

        currentHp = maxHP;

        HPbar.maxValue = maxHP;
    }

    void Update()
    {
        // Debug.Log(currentHp);
        if(currentHp < maxHP && !rungameFinished){
            hpTimer += Time.deltaTime;
            if(hpTimer > 1){
                currentHp += 1;
                // HPbar.value = (float)currentHp;
                hpTimer = 0;
            }
        }

        if(currentHp <= 0 && !rungameFinished){
            GameOver.GameOverShowPanel();
            rungameFinished = true;
        }
    
    HPbar.value = (float)currentHp;

    }

    public static void damageHP(int damage){
        currentHp -= damage;
        //Debug.Log("ダメージを受けました");
    }
}
