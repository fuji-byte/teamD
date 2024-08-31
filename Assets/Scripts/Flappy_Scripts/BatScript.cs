using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public SmartphoneSystem spsystem;
    public bool batIsAlive = true;
    public bool gameCleared = false;
    public GameObject player;
    public GameObject mainGameLogicObj;
    public TaskLogic mainGameLogic;

    // Start is called before the first frame update
    void Start()
    {
        batIsAlive = true;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        mainGameLogic = mainGameLogicObj.GetComponent<TaskLogic>();
        spsystem = player.GetComponent<SmartphoneSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spsystem.spDisplayed == true && mainGameLogic.rdm == 0){ //スマホが表示されていたら。
            if(Input.GetMouseButtonDown(0) == true && batIsAlive == true){
                myRigidbody.velocity = Vector3.up * flapStrength;
            }
            if((transform.position.y < -17 || transform.position.y > 17) && gameCleared == false){
                logic.gameOver();
                batIsAlive = false;
            }
            if(logic.playerScore >= 8){
                logic.gameClear();
                batIsAlive = false;
                gameCleared = true;
            }
            myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }else{
            myRigidbody.bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(gameCleared == false){
            logic.gameOver();
            batIsAlive = false;
        }
    }
}
