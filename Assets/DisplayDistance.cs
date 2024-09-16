using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class DisplayDistance : MonoBehaviour
{
    public TextMeshProUGUI distance;
    private static Rigidbody Playerrigid;
    public int distanceNum;
    // Start is called before the first frame update
    void Start()
    {
        Playerrigid = GameObject.Find("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceNum = (int)Mathf.Floor(Playerrigid.position.z)/5 ;
        distance.text = distanceNum.ToString();
    }
}
