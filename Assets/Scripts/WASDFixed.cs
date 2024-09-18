using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDFixed : MonoBehaviour
{
    private Rigidbody rigid;
    private AudioSource audioSource;

    public float PlayerSpeed = 20;
    public float PlayerLRSpeed = 10;

    public static bool operability = true;

    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Awake()
    {
        operability = true;
    }

    void FixedUpdate()
    {
        if (operability)
        {
            Vector3 force = Vector3.zero;

            force = new Vector3(0, 0, PlayerSpeed);

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                if (rigid.position.x >= -12)
                {
                    force = new Vector3(PlayerLRSpeed * -1, 0, PlayerSpeed);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                if (rigid.position.x <= 12)
                {
                    force = new Vector3(PlayerLRSpeed, 0, PlayerSpeed);
                }
            }

            if (force != Vector3.zero && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
            else if (force == Vector3.zero && audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            rigid.MovePosition(rigid.position + force * Time.fixedDeltaTime);
        }
    }
}
