using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public static int maxHP;
    public static int currentHp;
    public static Slider HPbar;
    float hpTimer;
    bool rungameFinished;
    // Start is called before the first frame update
    void Start()
    {
        HPbar = GameObject.Find("HPbar").GetComponent<Slider>();
        HPbar.value = 1;
        maxHP = 100;
        currentHp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentHp);
        if(currentHp < maxHP && rungameFinished == false){
            hpTimer += Time.deltaTime;
            if(hpTimer > 1){
                currentHp += 1;
                HPbar.value = (float)currentHp / (float)maxHP;
                hpTimer = 0;
            }
        }

        if(currentHp <= 0 && rungameFinished == false){
            GameOver.GameOverShowPanel();
            rungameFinished = true;
        }
    }

    public static void damageHP(int damage){
        currentHp -= damage;
        HPbar.value = (float)currentHp / (float)maxHP;
        Debug.Log("ダメージを受けました");
    }
}
