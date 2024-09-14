using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class Obstacle1HPFixed : MonoBehaviour
{
    private Rigidbody Playerrigid;
    private async void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            //HPManagerFixed.damageHP(50);
            CircleHPManager.damageHP(50);
            //ノックバック処理
            WASDFixed.operability = false;
            // Debug.Log("enter");
            Playerrigid = GameObject.Find("Player").GetComponent<Rigidbody>();
            Vector3 force = Vector3.zero;
            force = new Vector3( 0 , 0 , -1000);
            Playerrigid.MovePosition(Playerrigid.position + force * Time.fixedDeltaTime);
            await Task.Delay(1000);
            // Debug.Log("out");
            if(CircleHPManager.currentHp>0)
            WASDFixed.operability = true;
        }
    }
}
