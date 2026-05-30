using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] enemySpawnPoints;

    public float enemySpawnTime = 5f;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= enemySpawnTime)
        {
            SpawnEnemy();
            timer = 0f; 
        }
        
    }

    void SpawnEnemy()
    {
        int rastgeleIndeks = Random.Range(0, enemySpawnPoints.Length);
        Transform chosenPoint = enemySpawnPoints[rastgeleIndeks];

        Instantiate(enemyPrefab, chosenPoint.position, chosenPoint.rotation);
    }
}
