using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAScript : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("DontDestroyA");

        if (objects.Length > 1){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
