using UnityEngine;
using UnityEngine.SceneManagement;

public class Sample : MonoBehaviour
{

    public void OnLoadSceneAdditive()
    {
        //SceneBを加算ロード。現在のシーンは残ったままで、シーンBが追加される
        SceneManager.LoadScene("FlappyScene",LoadSceneMode.Additive);
    }
}
