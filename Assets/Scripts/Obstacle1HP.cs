using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1HP : MonoBehaviour
{
    HPManager hpManager;
    // Start is called before the first frame update
    void Start()
    {
        hpManager = GameObject.Find("HPbar").GetComponent<HPManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            HPManager.damageHP(50);
        }
    }
}
