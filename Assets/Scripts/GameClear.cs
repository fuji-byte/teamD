using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameClear : MonoBehaviour
{
    // Canvasコンポーネント
    private static Canvas gameClearCanvas;
    //CanvasGropeコンポーネント
    private static CanvasGroup gameClearCanvasGroup;

    private void Awake()
    {
        // Canvasコンポーネント取得
        gameClearCanvas = GetComponent<Canvas>();
        //CanvasGropeコンポーネント取得
        gameClearCanvasGroup = GetComponent<CanvasGroup>();
        // 初期状態は非表示にしておく
        gameClearCanvas.enabled = false;
    }

    // パネルを開く用の関数 static呼び出し可能
    public static void GameClearShowPanel()
    {
        //Playerのポジションを引数として渡す
        WASDFixed.operability = false;
        // GameClearCanvasを表示
        gameClearCanvas.enabled = true;

        // フェードイン開始
        GameClear instance = FindObjectOfType<GameClear>();//コルーチンを実行させるためのインスタンス
        if (instance != null)
        {
            instance.StartCoroutine(instance.ShowAndFade());//フェードイン処理の実行
        }
    }

    // フェードインして3秒後にフェードアウトするコルーチン
    private IEnumerator ShowAndFade()
    {
        yield return StartCoroutine(FadeIn()); // フェードイン

        yield return new WaitForSeconds(3f); // 3秒待機

        yield return StartCoroutine(FadeOut()); // フェードアウト

        gameClearCanvas.enabled = false; // フェードアウト完了後、キャンバスを非表示にする
    }

    // フェードイン処理
    private IEnumerator FadeIn()
    {
        float fadeDuration = 1f; // フェードインにかける時間（秒）
        float elapsedTime = 0f;//フェードインを開始してから経過した時間

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            gameClearCanvasGroup.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            yield return null;
        }

        gameClearCanvasGroup.alpha = 1f; // フェードイン完了
    }

    // フェードアウト処理
    private IEnumerator FadeOut()
    {
        float fadeDuration = 1f; // フェードアウトにかける時間（秒）
        float elapsedTime = 0f;//フェードアウトを開始してから経過した時間

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            gameClearCanvasGroup.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            yield return null;
        }

        gameClearCanvasGroup.alpha = 0f; // フェードアウト完了
    }
}