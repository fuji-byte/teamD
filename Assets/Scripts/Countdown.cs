using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using UnityEditor.ShaderGraph.Internal;
using JetBrains.Annotations;

public class Countdown : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    private void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        countdownDisplay.text = "START";
        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
        //FindObjectOfType<WASD>().enabled = true; // WASDスクリプトを有効にする
    }
}