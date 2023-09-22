using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
<<<<<<< HEAD

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

=======
    public GameObject EnemyGO;
    public float maxSpawnRateInSeconds = 5f;

    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        bool spawnFromTop = Random.value > 0.5f;

        GameObject anEnemy = Instantiate(EnemyGO);
        anEnemy.SetActive(true);

        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), spawnFromTop ? max.y + 0.5f : min.y - 0.5f);
        anEnemy.GetComponent<EnemyControl>().InitializeDirection(spawnFromTop ? Vector2.down : Vector2.up);
        
        ScheduleNextEnemySpawn();
    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;

        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;
        }

        Invoke("SpawnEnemy", spawnInNSeconds);
    }
>>>>>>> new-feature
}
