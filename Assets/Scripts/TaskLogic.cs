using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TaskLogic : MonoBehaviour
{
    public Camera flappyCamera;
    public Camera skeletonCamera;
    public Camera morseCamera;
    public Camera countCamera;
    public Camera noTaskCamera;
    public Component flappyCameraComp;
    public RenderTexture gameCameraTexture;
    public RenderTexture noneTexture;
    public TextMeshProUGUI countDownNum;
    public Image tuuti1, tuuti2, tuuti3, tuuti4;
    public static bool taskWaiting = false; //タスク発生待ちかどうか。タスクごとに失敗/クリア時にtrueにする処理を入れる必要あり。
    public static int rdm;
    public static int turn=10;
    public AudioSourceScript audioSourceScript;

    int[] array = new int[3];
    // Start is called before the first frame update
    async void Start()
    {
        turn=10;
        flappyCamera = GameObject.Find("FlappyCamera").GetComponent<Camera>();
        skeletonCamera = GameObject.Find("SkeletonCamera").GetComponent<Camera>();
        morseCamera = GameObject.Find("MorseCamera").GetComponent<Camera>();
        countCamera = GameObject.Find("CountCamera").GetComponent<Camera>();
        audioSourceScript = GameObject.Find("AudioSourceObject").GetComponent<AudioSourceScript>();
        rdm = 100;
        gameCameraTexture = Resources.Load<RenderTexture>("Flappy Render");
        noneTexture = Resources.Load<RenderTexture>("None Render");
        flappyCamera.targetTexture = noneTexture;
        skeletonCamera.targetTexture = noneTexture;
        morseCamera.targetTexture = noneTexture;
        countCamera.targetTexture = noneTexture;
        noTaskCamera.targetTexture = gameCameraTexture; //初期はなにも表示しない画面
        await firstTask();
    }

    // Update is called once per frame
    async void Update()
    {
        if(taskWaiting == true){
            taskWaiting = false;
            await countDownSystem();
        }
    }

    private async UniTask firstTask(){
        await UniTask.Delay(TimeSpan.FromSeconds(3f));
        await countDownSystem(); //開始5秒後にタスク発生
        //happenTask();
    }

    public async UniTask countDownSystem(){
        tuuti1.gameObject.SetActive(false);
        tuuti2.gameObject.SetActive(false);
        tuuti3.gameObject.SetActive(false);
        tuuti4.gameObject.SetActive(false);

        if(GenerateLevels.TaskCleared == 2){
            tuuti1.gameObject.SetActive(true);
        }else if(GenerateLevels.TaskCleared == 4){
            tuuti2.gameObject.SetActive(true);
        }else if(GenerateLevels.TaskCleared == 6){
            tuuti3.gameObject.SetActive(true);
        }else if(GenerateLevels.TaskCleared == 8){
            tuuti4.gameObject.SetActive(true);
        }

        if ((GenerateLevels.TaskCleared % 2) == 0)
        {
            audioSourceScript.MonsterScreamM();
        }

            await UniTask.Delay(TimeSpan.FromSeconds(2f));
        flappyCamera.targetTexture = noneTexture;
        skeletonCamera.targetTexture = noneTexture;
        morseCamera.targetTexture = noneTexture;
        noTaskCamera.targetTexture = gameCameraTexture;
        int countDown = 5;
        while(countDown > 0){
            countDownNum.text = countDown.ToString();
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            countDown--;
        }
        happenTask();
    }

    public async void happenTask(){
        // rdm = Random.Range(0, 3); // 0...FlappyBird 1...Skeleton 2...Morse
        if(turn>2)
        {
            array[0]=Random.Range(0, 3);
            while(array[0]==array[1])
            {
                array[1]=Random.Range(0, 3);
            }
            while(array[0]==array[2]||array[1]==array[2])
            {
                array[2]=Random.Range(0, 3);
            }
            turn=0;
        }
        rdm=array[turn];
        flappyCamera.targetTexture = noneTexture;
        skeletonCamera.targetTexture = noneTexture;
        morseCamera.targetTexture = noneTexture;
        noTaskCamera.targetTexture = noneTexture;

        switch(rdm){
            case 0:
                GameManager.flappyReset();
                await WaitForSceneToLoad("FlappyBat");
                Debug.Log("ゲーム画面をスマホに映します");
                flappyCamera = GameObject.Find("FlappyCamera").GetComponent<Camera>();
                flappyCamera.targetTexture = gameCameraTexture;
                turn++;
                break;
            case 1:
            GameManager.skeletonReset();
            await WaitForSceneToLoad("skeletonkill");
            Debug.Log("ゲーム画面をスマホに映します");
            skeletonCamera = GameObject.Find("SkeletonCamera").GetComponent<Camera>();
            skeletonCamera.targetTexture = gameCameraTexture;
            turn++;
                break;
            case 2:
            GameManager.morseReset();
            await WaitForSceneToLoad("MorseMinigame");
            Debug.Log("ゲーム画面をスマホに映します");
            morseCamera = GameObject.Find("MorseCamera").GetComponent<Camera>();
            morseCamera.targetTexture = gameCameraTexture;
            turn++;
                break;
        }
    }

    private async UniTask WaitForSceneToLoad(string sceneName) {
        while (!SceneManager.GetSceneByName(sceneName).isLoaded) {
            await UniTask.Yield();
        }
    }
}
