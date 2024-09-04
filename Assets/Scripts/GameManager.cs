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
        SceneManager.SetActiveScene(flappyScene);
        SceneManager.SetActiveScene(skeletonScene);
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
        //Scene flappyScene = SceneManager.GetSceneAt(1);
        //Scene flappyScene = SceneManager.GetSceneByName("FlappyBat");
        //SceneManager.SetActiveScene(flappyScene);
        
        //Scene skeletonScene = SceneManager.GetSceneAt(2);
        //Scene skeletonScene = SceneManager.GetSceneByName("skeletonkill");
        //SceneManager.SetActiveScene(skeletonScene);

    }
}
