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

    private IEnumerator Start()
    {
        textLabel.text = word[num];
        yield return StartCoroutine(textFadeIn());
    }
 
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(num == word.Length - 1)
            {
                SceneManager.LoadScene("Result");
                return;
            }
 
            AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position, 0.5f);
 
            num += 1;
 
            textLabel.text = word[num];
            if(num == word.Length - 1){
                bottomText.gameObject.SetActive(true);
            }
        }
    }

    public IEnumerator textFadeIn(){
        Color textLabelColor = textLabel.color;
        float fadeDuration = 1f; // フェードインにかける時間（秒）
        float elapsedTime = 0f;//フェードインを開始してから経過した時間

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            textLabelColor.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            textLabel.color = textLabelColor;
            yield return null;
        }

        textLabelColor.a = 1f; // フェードイン完了
    }
}