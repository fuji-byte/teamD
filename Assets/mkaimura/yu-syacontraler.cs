using UnityEngine;

public class HeroAttack : MonoBehaviour
{
    private Animator animator;
    public AudioClip swordSound;
    public GameController gameControllerScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if(TaskLogic.rdm == 1){
            if (Input.GetMouseButtonDown(0)) // ���N���b�N
            {
                if(gameControllerScript.MKI_gameFinished == false){
                animator.SetTrigger("Attack");
                AudioSource.PlayClipAtPoint(swordSound, Camera.main.transform.position, 0.25f);
                }
            }
        }
    }
}
