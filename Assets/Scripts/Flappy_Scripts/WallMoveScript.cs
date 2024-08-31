using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveScript : MonoBehaviour
{
    public float moveSpeed = 6;
    public float deadZone = -35;
    public SmartphoneSystem spsystem;
    public TaskLogic mainGameLogic;
    // Start is called before the first frame update
    void Start()
    {
        spsystem = GameObject.Find("Player").GetComponent<SmartphoneSystem>();
        mainGameLogic = GameObject.Find("MainGameLogic").GetComponent<TaskLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spsystem.spDisplayed == true && mainGameLogic.rdm == 0){
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

            if(transform.position.x < deadZone){
                Destroy(gameObject);
            }
        }
    }


}
