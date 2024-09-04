using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    public Animator animator;
    public float time;
    public int MKI_clickCount;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(TaskLogic.rdm == 1){
            if (time <= 0 || MKI_clickCount >= 70)
            {
                if (Input.GetMouseButtonDown(0)) // ���N���b�N
                {
                    animator.SetTrigger("Fall");
                }
            }
        }
            
    }
}
