using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    //public GameObject mainGameLogicObj;
    //public TaskLogic mainGameLogic;
    // Start is called before the first frame update
    void Start()
    {
        //mainGameLogic = mainGameLogicObj.GetComponent<TaskLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TaskLogic.rdm == 0){
        gameObject.transform.position = gameObject.transform.position + Vector3.left * 0.01f;
        }
    }
}
