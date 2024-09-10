using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(TaskLogic.rdm == 1){
            if (Input.GetMouseButtonDown(0)) // ���N���b�N
            {
                animator.SetTrigger("Attack");
            }
        }
    }
}
