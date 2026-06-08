using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float spawnTimer = 0.5f;
    public float range;


    void Start()
    {

    }
    void Update()
    {
        TimerMechanic();
    }
    public void TimerMechanic()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            SpawnEnemy();
            spawnTimer = 0.5f;
        }
    }
    public void SpawnEnemy()
    {
        Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        Vector3 fullLenghtDir = randomDir * Random.Range(0f, range);
        GameObject enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        enemy.transform.position += fullLenghtDir;
    }
}
        