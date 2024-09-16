using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public FadeController fadeController; // フェードコントローラーへの参照

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        // フェードアウトを開始し、完了後に"RunGameScene_smartphone_system"に遷移
        fadeController.StartFadeOut("OP_RunGame");
    }
}