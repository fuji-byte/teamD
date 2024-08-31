using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class SmartphoneSystem : MonoBehaviour
{
    public bool spDisplayed = false;
    public GameObject smartphone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //スマホ表示・非表示。
        //if(Input.GetKeyDown(KeyCode.Q)){
        //    if(spDisplayed == true){
        //        smartphone.SetActive(false);
        //        spDisplayed = false;
        //    }else{
        //        smartphone.SetActive(true);
        //        spDisplayed = true;
        //    }
        //}

    }
}
