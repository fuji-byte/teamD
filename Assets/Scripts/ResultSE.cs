using UnityEngine;

public class ResultSE : MonoBehaviour
{
    public AudioClip seClip1;
    public AudioClip seClip2;

    private AudioSource audioSource1;
    private AudioSource audioSource2;

    void Start()
    {
        audioSource1 = GetComponents<AudioSource>()[0]; // 0番目の AudioSource
        audioSource2 = GetComponents<AudioSource>()[1]; // 1番目の AudioSource
    }

    public void PlaySE1()
    {
        audioSource1.PlayOneShot(seClip1);
    }

    public void PlaySE2()
    {
        audioSource2.PlayOneShot(seClip2);
    }

}

