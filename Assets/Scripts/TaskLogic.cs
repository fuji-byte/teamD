using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TaskLogic : MonoBehaviour
{
    public Camera flappyCamera;
    public Camera skeletonCamera;
    public Camera morseCamera;
    public Camera noTaskCamera;
    public Component flappyCameraComp;
    public RenderTexture gameCameraTexture;
    public RenderTexture noneTexture;
    public static bool taskWaiting = false; //タスク発生待ちかどうか。タスクごとに失敗/クリア時にtrueにする処理を入れる必要あり。
    public static int rdm;
    // Start is called before the first frame update
    async void Start()
    {
        flappyCamera = GameObject.Find("FlappyCamera").GetComponent<Camera>();
        skeletonCamera = GameObject.Find("SkeletonCamera").GetComponent<Camera>();
        morseCamera = GameObject.Find("MorseCamera").GetComponent<Camera>();
        rdm = 100;
        gameCameraTexture = Resources.Load<RenderTexture>("Flappy Render");
        noneTexture = Resources.Load<RenderTexture>("None Render");
        flappyCamera.targetTexture = noneTexture;
        skeletonCamera.targetTexture = noneTexture;
        morseCamera.targetTexture = noneTexture;
        noTaskCamera.targetTexture = gameCameraTexture; //初期はなにも表示しない画面
        await firstTask();
    }

    // Update is called once per frame
    async void Update()
    {
        if(taskWaiting == true){
            taskWaiting = false;
            await normalTask();
        }
    }

    private async UniTask firstTask(){
        Debug.Log("5秒後にタスクを送ります");
        await UniTask.Delay(TimeSpan.FromSeconds(10f)); //開始5秒後にタスク発生
        Debug.Log("firstタスクを送りました");
        happenTask();
    }
    
    private async UniTask normalTask(){
        Debug.Log("10秒後にタスクを送ります");
        await UniTask.Delay(TimeSpan.FromSeconds(10f)); //開始10秒後にタスク発生
        Debug.Log("normalタスクを送りました");
        happenTask();
    }

    public async void happenTask(){
        rdm = Random.Range(0, 3); // 0...FlappyBird 1...Skeleton 2...Morse
        flappyCamera.targetTexture = noneTexture;
        skeletonCamera.targetTexture = noneTexture;
        morseCamera.targetTexture = noneTexture;
        noTaskCamera.targetTexture = noneTexture;

        if(rdm == 0){
            GameManager.flappyReset();
            await WaitForSceneToLoad("FlappyBat");
            Debug.Log("ゲーム画面をスマホに映します");
            flappyCamera = GameObject.Find("FlappyCamera").GetComponent<Camera>();
            flappyCamera.targetTexture = gameCameraTexture;
        }
        if(rdm == 1){
            GameManager.skeletonReset();
            await WaitForSceneToLoad("skeletonkill");
            Debug.Log("ゲーム画面をスマホに映します");
            skeletonCamera = GameObject.Find("SkeletonCamera").GetComponent<Camera>();
            skeletonCamera.targetTexture = gameCameraTexture;
        }
        if(rdm == 2){
            GameManager.morseReset();
            await WaitForSceneToLoad("MorseMinigame");
            Debug.Log("ゲーム画面をスマホに映します");
            morseCamera = GameObject.Find("MorseCamera").GetComponent<Camera>();
            morseCamera.targetTexture = gameCameraTexture;
        }
    }

    private async UniTask WaitForSceneToLoad(string sceneName) {
        while (!SceneManager.GetSceneByName(sceneName).isLoaded) {
            await UniTask.Yield();
        }
    }
}
