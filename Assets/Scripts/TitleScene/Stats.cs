using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
{
    //数値の更新
    // StatsValue.renew();
    // BestRecordUpdate();
    //シーンへ移動
    SceneManager.LoadScene("Stats");
}
}
