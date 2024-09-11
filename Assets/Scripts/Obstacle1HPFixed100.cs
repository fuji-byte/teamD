using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1HPFixed100 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            HPManagerFixed.damageHP(100);
        }
    }
}
