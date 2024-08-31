using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject gameClearScreen;
    public GameObject mainGameLogicObj;
    public TaskLogic mainGameLogic;

    void Start(){
        mainGameLogic = mainGameLogicObj.GetComponent<TaskLogic>();
    }
    public void addScore(int scoreToAdd){
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
        mainGameLogic.taskWaiting = true;
    }

    public void gameClear(){
        gameClearScreen.SetActive(true);
        mainGameLogic.taskWaiting = true;
    }
}
