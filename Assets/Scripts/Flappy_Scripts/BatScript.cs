using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool batIsAlive = true;
    public bool gameCleared = false;

    // Start is called before the first frame update
    void Start()
    {
        batIsAlive = true;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(gameCleared == false){
            logic.gameOver();
            batIsAlive = false;
        }
    }
}
