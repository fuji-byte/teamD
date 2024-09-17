using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public void OnClick()
    {
        //数値の更新
        //OnClickにて実装
        //シーンへ移動
        SceneManager.LoadScene("Stats");
    }
}
