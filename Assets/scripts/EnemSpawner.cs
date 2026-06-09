using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab1;
    public GameObject EnemyPrefab2;
    public float spawnTimer = 0.5f;
    public float range;
    public int maxEnemies = 10;
    public Transform playerTransform;
    public float distanciaLimite = 5f;


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

            int currentEnemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;


            if (currentEnemiesCount < maxEnemies)
            {
                int randoEnemy = Random.Range(0, 2);

                if (randoEnemy == 0)
                {
                    SpawnEnemy(EnemyPrefab1);
                }
                else
                {
                    GameObject Enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
                    if (Enemy2 == null)
                    {
                        SpawnEnemy(EnemyPrefab2);
                    }
                    else if (playerTransform != null)
                    {
                        float distanceEnemy2ToPlayer = Vector3.Distance(Enemy2.transform.position, playerTransform.position);
                        if (distanceEnemy2ToPlayer > distanciaLimite)
                        {
                            SpawnEnemy(EnemyPrefab2);
                        }
                    }
                }
                spawnTimer = 2.0f;
            }
        }
    }
    public void SpawnEnemy(GameObject enemyPrefabToClone)
    {
        Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        Vector3 fullLenghtDir = randomDir * Random.Range(0f, range);
        GameObject enemyInstance = Instantiate(enemyPrefabToClone, transform.position, Quaternion.identity);
        enemyInstance.transform.position += fullLenghtDir;
    }
}
        