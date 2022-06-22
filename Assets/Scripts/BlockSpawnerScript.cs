using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawnerScript : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public float timeBetweenSpawns = 1;
    public Vector2 timeBetweenSpawnsMaxMin = new Vector2(1.5f,0.4f);
    private float nextSpawnTime = 0;
    private Vector2 halfScreenSize;
    private float maxSpawnAngle = 8;
    private Vector2 scaleMinMax = new Vector2(0.2f,2f);
    // Start is called before the first frame update
    void Start()
    {
        halfScreenSize = new Vector2(Camera.main.orthographicSize*Camera.main.aspect,Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenSpawns = Mathf.Lerp(timeBetweenSpawnsMaxMin.x,timeBetweenSpawnsMaxMin.y,Difficulty.GetDifficultyPercentage());

        if(Time.time > nextSpawnTime){
            Vector2 spawnPosition = new Vector2(Random.Range(-halfScreenSize.x,halfScreenSize.x),halfScreenSize.y);
            Vector3 spawnRotation = Vector3.forward*Random.Range(-maxSpawnAngle,maxSpawnAngle);
            GameObject fallingBlock = Instantiate(fallingBlockPrefab,spawnPosition,Quaternion.Euler(spawnRotation));
            fallingBlock.transform.localScale = Vector2.one*Random.Range(scaleMinMax.x,scaleMinMax.y);
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }

    }
}
