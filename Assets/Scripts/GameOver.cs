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

    private void Awake()
    {
        // Canvasコンポーネント取得
        gameOverCanvas = GetComponent<Canvas>();
        //CanvasGropeコンポーネント取得
        canvasGroup = GetComponent<CanvasGroup>();

        Playerrigid = GameObject.Find("Player").GetComponent<Rigidbody>();

        // 初期状態は非表示にしておく
        gameOverCanvas.enabled = false;
    }

    // パネルを開く用の関数 static呼び出し可能
    public static void GameOverShowPanel()
    {

        // GameOverCanvasを表示
        gameOverCanvas.enabled = true;

        WASDFixed.operability = false;

        distance1 = Playerrigid.position.z/5;

        StatsValue.LengthUpdate(MathF.Floor(distance1));
        // Debug.Log("distance1"+distance1);

        // フェードイン開始
        GameOver instance = FindObjectOfType<GameOver>();//コルーチンを実行させるためのインスタンス
        if (instance != null)//
        {
            instance.StartCoroutine(instance.FadeIn());//フェードイン処理の実行
        }
        SceneManager.LoadScene("Result");

        if (flag == true)
        {
            //if (Input.GetMouseButtonDown(0))
            //{
                SceneManager.LoadScene("Result");
            //}
        }
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