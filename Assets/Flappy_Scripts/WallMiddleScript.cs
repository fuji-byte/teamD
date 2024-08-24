using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    public BatScript batScript;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        batScript = GameObject.FindGameObjectWithTag("Bat").GetComponent<BatScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 3 && batScript.batIsAlive){
            logic.addScore(1);
        }

    }
}
