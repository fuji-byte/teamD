using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class WallSpawnScript : MonoBehaviour
{
    public GameObject wall;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnWall();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate){
            timer += Time.deltaTime;
        }else{
            spawnWall();
            timer = 0;
        }

    }

    void spawnWall(){
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(wall, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
