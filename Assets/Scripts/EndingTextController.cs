using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
 
public class EndingTextController : MonoBehaviour
{
    public TextMeshProUGUI textLabel;
    public TextMeshProUGUI bottomText;
    public string[] word;
    public AudioClip sound;
    private int num = 0;
 
    private void Start()
    {
        textLabel.text = word[num];
    }
 
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(num == word.Length - 1)
            {
                //SceneManager.LoadScene();
            }
 
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, 0.5f);
 
            num += 1;
 
            textLabel.text = word[num];
            if(num == word.Length - 1){
                bottomText.gameObject.SetActive(true);
            }
        }
    }
}