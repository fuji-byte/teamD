using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.LoadSceneAsync("FlappyBat", LoadSceneMode.Additive); //FlappyBatをロード。
        Scene flappyScene = SceneManager.GetSceneAt(1);
        SceneManager.LoadSceneAsync("skeletonkill", LoadSceneMode.Additive);
        Scene skeletonScene = SceneManager.GetSceneAt(2);
        SceneManager.LoadSceneAsync("MorseMinigame", LoadSceneMode.Additive);
        Scene morseScene = SceneManager.GetSceneAt(3);
        SceneManager.LoadSceneAsync("CountDownGame", LoadSceneMode.Additive);
        Scene countScene = SceneManager.GetSceneAt(4);
        SceneManager.SetActiveScene(flappyScene);
        SceneManager.SetActiveScene(skeletonScene);
        SceneManager.SetActiveScene(morseScene);
        SceneManager.SetActiveScene(countScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void flappyReset(){
        Debug.Log("シーンをリロードします");
        SceneManager.UnloadSceneAsync("FlappyBat");
        SceneManager.LoadScene("FlappyBat", LoadSceneMode.Additive);
    }
    public static void skeletonReset(){
        Debug.Log("シーンをリロードします");
        SceneManager.UnloadSceneAsync("skeletonkill");
        SceneManager.LoadScene("skeletonkill", LoadSceneMode.Additive);
    }
    public static void morseReset(){
        Debug.Log("シーンをリロードします");
        SceneManager.UnloadSceneAsync("MorseMinigame");
        SceneManager.LoadScene("MorseMinigame", LoadSceneMode.Additive);
    }
    public static void countReset(){
        Debug.Log("シーンをリロードします");
        SceneManager.UnloadSceneAsync("CountDownGame");
        SceneManager.LoadScene("CountDownGame", LoadSceneMode.Additive);
    }
}
