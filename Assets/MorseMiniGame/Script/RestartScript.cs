using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReset : MonoBehaviour
{
    public void ResetScene()
    {
        // 現在のシーンを再読み込みしてリセット
        SceneManager.LoadScene("MorseMinigame");
    }
}