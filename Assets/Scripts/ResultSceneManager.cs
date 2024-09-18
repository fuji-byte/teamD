using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class ResultSceneManager : MonoBehaviour
{
    // UI要素への参照 (Inspectorで設定できるようにpublicにする)
    public Image escapedScreen;
    public Image failedScreen;
    public Text taskText;
    public Text distanceText;
    public Image[] rankImages; 
    public Button titleButton;
    public Button retryButton;

    // フェードインの速さ
    public float fadeInDuration = 1f;

    public static bool escaped;//脱出の成否用のbool

    public FadeController fadeController; // フェードコントローラーへの参照

    public float distance = 0;

    public ResultSE resultse;

    private bool background=false;

    void Start()
    {
        //escapedに脱出の成否を保存
        background= false;

        //デバッグ用距離とタスククリア変更

        // 初期設定 (alpha値の設定、ゲームオブジェクトの非アクティブ化)
        distanceText.text="";
        taskText.text="";
        // ボタンのクリックイベントを設定 (実装できそうなら)
        if (titleButton != null)
        {
            titleButton.onClick.AddListener(() => SceneManager.LoadScene("TitleScene")); 
        }
        if (retryButton != null)
        {
            retryButton.onClick.AddListener(() => SceneManager.LoadScene("RunGameScene_smartphone_system")); 
        }

        // リザルト表示開始
        ShowResult();
    }

    void ShowResult()
    {
        // 値の取得と表示 (ResultValueから値を取得してTextに設定)

        // 脱出成功/失敗に応じてベース画像をフェードイン
        Image baseImage = (escaped) ? escapedScreen : failedScreen;//条件成功失敗(真:偽)
        StartCoroutine(FadeIn(baseImage, fadeInDuration,0f));

        // タスククリア数表示（フェードイン）
        taskText.text+=GenerateLevels.TaskCleared;
        taskText.gameObject.SetActive(true);
        StartCoroutine(FadeInText(taskText, fadeInDuration,1f));

        // 脱出距離表示 (脱出成功時のみ、フェードイン)
        if (escaped)//条件成功失敗
        {
            distanceText.text+= Obstacle.distance2;
            distanceText.gameObject.SetActive(true);
            StartCoroutine(FadeInText(distanceText, fadeInDuration,2f));
        }

        // ランク画像をフェードイン
        int rankIndex = CalculateRank(GenerateLevels.TaskCleared, distance);
        rankImages[rankIndex].gameObject.SetActive(true);
        if(escaped==false){
            StartCoroutine(FadeIn(rankImages[rankIndex].GetComponent<Image>(), fadeInDuration,3f));
            StartCoroutine(ScaleDownImage(rankImages[rankIndex].GetComponent<Image>(), fadeInDuration,3f));
        }
        else{
            StartCoroutine(FadeIn(rankImages[rankIndex].GetComponent<Image>(), fadeInDuration,4f));
            StartCoroutine(ScaleDownImage(rankImages[rankIndex].GetComponent<Image>(), fadeInDuration,4f));
        }

        if(escaped==false){// ボタン表示
        StartCoroutine(FadeInButton(titleButton, fadeInDuration,4f));
        StartCoroutine(FadeInButton(retryButton, fadeInDuration,4f));
        }else{
        StartCoroutine(FadeInButton(titleButton, fadeInDuration,5f));
        StartCoroutine(FadeInButton(retryButton, fadeInDuration,5f));
        }
    }

IEnumerator FadeIn(Image image, float duration,float timer)
{
    float elapsedTime = 0f;
    Color originalColor = image.color; // 元の色を保持
    yield return new WaitForSeconds(timer);
    if(background==true)resultse.PlaySE2();
    while (elapsedTime < duration)
    {
        elapsedTime += Time.deltaTime;
        float newAlpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);
        image.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha); 
        yield return null;
    }
    background=true;
}

IEnumerator FadeInText(Text text, float duration,float timer)
{
    float elapsedTime = 0f;
    Color originalColor = text.color; // 元の色を保持
    yield return new WaitForSeconds(timer);
    resultse.PlaySE1();
    while (elapsedTime < duration)
    {
        elapsedTime += Time.deltaTime;
        float newAlpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha); 
        yield return null;
    }
}

IEnumerator FadeInButton(Button button, float duration,float timer)
{
    Image buttonImage = button.GetComponent<Image>();
    float elapsedTime = 0f;
    Color originalColor = buttonImage.color; // 元の色を保持
    yield return new WaitForSeconds(timer);
    while (elapsedTime < duration)
    {
        elapsedTime += Time.deltaTime;
        float newAlpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);
        buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha); 
        yield return null;
    }
    button.gameObject.SetActive(true);
}

IEnumerator ScaleDownImage(Image image, float duration, float timer){
    float elapsedTime = 0f;
    RectTransform imageRectTransform;
    imageRectTransform = image.gameObject.GetComponent<RectTransform>();
    Vector2 scale = imageRectTransform.localScale;
    //Color originalColor = image.color; // 元の色を保持
    yield return new WaitForSeconds(timer);
    //if(background==true)resultse.PlaySE2();
    while (elapsedTime < duration)
    {
        elapsedTime += Time.deltaTime;
        scale.x = Mathf.Lerp(scale.x, 1f, 0.02f);
        scale.y = Mathf.Lerp(scale.y, 1f, 0.02f);
        imageRectTransform.localScale = scale;
        yield return null;
    }
    background=true;
}

    int CalculateRank(int taskClearCount, float escapeDistance)
    {
        if (escaped) // 脱出成功時
        {

            if (escapeDistance >= 1400) return 2;      // A:2
            if (escapeDistance >= 1000) return 3;      // A+:3
            return 4;   //S:4
        }
        else // 脱出成功時
        {
            return (taskClearCount <= 4) ? 0 : 1; // C: 0, B: 1（真:偽）
        }
    }
}