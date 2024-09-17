using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmartNotice : MonoBehaviour
{
    public GameObject target;
    private Rigidbody rigid;

    private float Move;

    private bool TB;

    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
    Vector3 force = new Vector3( 0 , 10 , 0 );
    transform.position = Vector3.Lerp(transform.position, force, 1/2);
    }

}

