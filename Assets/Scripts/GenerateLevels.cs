using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GenerateLevels : MonoBehaviour
{
    public GameObject[] level;
    public int zPos = 50;
    // zの軸の座標
    public bool creatingLevel = false;
    public int lvlNum;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        if (!creatingLevel)
        {
            creatingLevel = true;
            StartCoroutine(GenerateLvl());
        }
    }
 
    IEnumerator GenerateLvl()
    {
        lvlNum = Random.Range(0, 9); // 0, 1, 2, 3,...,8
        Instantiate(level[lvlNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        //z座標がどれだけ進んで生成されるか
        yield return new WaitForSeconds(2);
        //何秒ごとに道を生成するか
        creatingLevel = false;
    }
}