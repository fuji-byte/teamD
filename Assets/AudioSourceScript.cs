using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AudioSourceScript : MonoBehaviour
{
    public AudioClip flappyBatWing;
    public AudioClip makaimuraHeroAttack;
    public AudioClip morseShort;
    public AudioClip morseLong;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void flappyBatWingM(){
        audioSource.PlayOneShot(flappyBatWing, 0.1f);
    }
    public void makaimuraHeroAttackM(){
        audioSource.PlayOneShot(makaimuraHeroAttack, 0.1f);
    }
    public void morseShortM(){
        audioSource.PlayOneShot(morseShort, 0.1f);
    }
    public void morseLongM(){
        audioSource.PlayOneShot(morseLong, 0.1f);
    }
}
