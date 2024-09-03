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
        SceneManager.SetActiveScene(flappyScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
