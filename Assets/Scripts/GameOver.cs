using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GameOver : MonoBehaviour
{
    // Canvasコンポーネント
    private static Canvas gameOverCanvas;
    //CanvasGropeコンポーネント
    private static CanvasGroup canvasGroup; 

    private static Rigidbody Playerrigid;

    public static float distance1;

    private static bool flag = false;

    public AudioClip gameover;
    public AudioSourceScript audioSourceScript;

    private void Awake()
    {
        // Canvasコンポーネント取得
        gameOverCanvas = GetComponent<Canvas>();
        //CanvasGropeコンポーネント取得
        canvasGroup = GetComponent<CanvasGroup>();

        Playerrigid = GameObject.Find("Player").GetComponent<Rigidbody>();

        audioSourceScript = GameObject.Find("AudioSourceObject").GetComponent<AudioSourceScript>();

        // 初期状態は非表示にしておく
        gameOverCanvas.enabled = false;

        flag = false;
    }

    private void Update()
    {
        // フェードインが完了していて、左クリックが押された場合
        if (flag && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("Result");
        }
    }

    public static void StopFootsteps()
    {
        WASDFixed instance = FindObjectOfType<WASDFixed>();
        if (instance != null)
        {
            AudioSource audioSource = instance.GetComponent<AudioSource>();
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    // パネルを開く用の関数 static呼び出し可能
    public static void GameOverShowPanel()
    {

        // GameOverCanvasを表示
        gameOverCanvas.enabled = true;

        StopFootsteps();

        WASDFixed.operability = false;

        distance1 = Playerrigid.position.z / 5;

        ResultSceneManager.escaped = false;

        StatsValue.LengthUpdate(MathF.Floor(distance1));
        // Debug.Log("distance1"+distance1);

        // フェードイン開始
        GameOver instance = FindObjectOfType<GameOver>();//コルーチンを実行させるためのインスタンス
        if (instance != null)//
        {
            instance.audioSourceScript.gameoverM();
            instance.StartCoroutine(instance.FadeIn());//フェードイン処理の実行
        }
        //SceneManager.LoadScene("Result");
    }

    // フェードイン処理
    private IEnumerator FadeIn()
    {
        float fadeDuration = 1f; // フェードインにかける時間（秒）
        float elapsedTime = 0f;//フェードインを開始してから経過した時間

        while (elapsedTime <= fadeDuration)
        {
            elapsedTime += Time.deltaTime;//elapsedTimeに1フレーム追加
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);//alpha値の変更
            yield return null;
        }

        canvasGroup.alpha = 1f; // フェードイン完了
        flag = true;
    }
}