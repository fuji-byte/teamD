using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    //public SmartphoneSystem spsystem;
    public bool batIsAlive = true;
    public bool gameCleared = false;
    public bool gameFinished = false;
    public AudioClip batSound;
    //public GameObject player;
    //public GameObject mainGameLogicObj;
    //public TaskLogic mainGameLogic;

    // Start is called before the first frame update
    void Start()
    {
        batIsAlive = true;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //mainGameLogic = mainGameLogicObj.GetComponent<TaskLogic>();
        //spsystem = player.GetComponent<SmartphoneSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TaskLogic.rdm == 0){ //スマホが表示されていたら。spsystem.spDisplayed == true && 
            if(Input.GetMouseButtonDown(0) == true && batIsAlive == true){
                myRigidbody.velocity = Vector3.up * flapStrength;
                AudioSource.PlayClipAtPoint(batSound, Camera.main.transform.position, 0.2f);
            }
            if((transform.position.y < -17 || transform.position.y > 17) && gameCleared == false){
                if(gameFinished == false){
                    gameFinished = true;
                    logic.gameOver();
                    batIsAlive = false;
                }
            }
            if(logic.playerScore >= 6){
                if(gameFinished == false){
                    gameFinished = true;
                    logic.gameClear();
                    batIsAlive = false;
                    gameCleared = true;
                }
            }
            myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }else{
            myRigidbody.bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Wall"){
            if(gameCleared == false && gameFinished == false){
                gameFinished = true;
                logic.gameOver();
                batIsAlive = false;
            }
        }
    }
}
