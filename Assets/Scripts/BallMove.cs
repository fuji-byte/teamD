using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float BallSpeed = -10f;

    private Rigidbody Ballrigid;

    private Rigidbody Playerrigid;

    void Start()
    {
        Ballrigid = this.gameObject.GetComponent<Rigidbody>();

        Playerrigid = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(WASDFixed.operability&&(Ballrigid.position.z-Playerrigid.position.z)<=200)
        {
            Vector3 force = Vector3.zero;

        force = new Vector3( 0 , 0 , BallSpeed);

        Ballrigid.MovePosition(Ballrigid.position + force * Time.fixedDeltaTime);
        }
    }

}
