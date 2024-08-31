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
    public Camera testTaskCamera;
    public Camera noTaskCamera;
    public Component flappyCameraComp;
    public RenderTexture gameCameraTexture;
    public RenderTexture noneTexture;
    public bool taskWaiting = false; //タスク発生待ちかどうか。タスクごとに失敗/クリア時にtrueにする処理を入れる必要あり。
    public int rdm;
    // Start is called before the first frame update
    async void Start()
    {
        rdm = 100;
        flappyCameraComp = flappyCamera.GetComponent<Camera>();
        gameCameraTexture = Resources.Load<RenderTexture>("Flappy Render");
        noneTexture = Resources.Load<RenderTexture>("None Render");
        flappyCamera.targetTexture = noneTexture;
        testTaskCamera.targetTexture = noneTexture;
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
        await UniTask.Delay(TimeSpan.FromSeconds(5f)); //開始5秒後にタスク発生
        happenTask();
    }
    
    private async UniTask normalTask(){
        await UniTask.Delay(TimeSpan.FromSeconds(10f)); //開始5秒後にタスク発生
        happenTask();
    }

    public void happenTask(){
        rdm = Random.Range(0, 2); //0...FlappyBird 1...test。
        //以下初期化処理。ゲームが増えるごとに処理を増やすこと。
        flappyCamera.targetTexture = noneTexture;
        testTaskCamera.targetTexture = noneTexture;
        noTaskCamera.targetTexture = noneTexture;
        if(rdm == 0){
            flappyCamera.targetTexture = gameCameraTexture;
        }
        if(rdm == 1){
            testTaskCamera.targetTexture = gameCameraTexture;
        }
    }
}
