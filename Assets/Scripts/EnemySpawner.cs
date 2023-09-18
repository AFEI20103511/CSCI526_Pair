using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject EnemyGO;

    float maxSpawRateInSeconds = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke ("SpawnEnemy", maxSpawRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 30f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy() {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2 (0,0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2 (1,1));

        GameObject anEnemy = (GameObject) Instantiate(EnemyGO);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextEnemySpawn();

    }

    void ScheduleNextEnemySpawn() {
        float spawnInSeconds;
        if(maxSpawRateInSeconds > 1f) {
            spawnInSeconds = Random.Range(1f, maxSpawRateInSeconds);
        } else {
            spawnInSeconds = 1f;
        }
        Invoke("SpawnEnemy", spawnInSeconds);
    }

    void IncreaseSpawn() {
        if(maxSpawRateInSeconds > 1f) {
            maxSpawRateInSeconds--;
        } 
        if(maxSpawRateInSeconds == 1f) {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

}
