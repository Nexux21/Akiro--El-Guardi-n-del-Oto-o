using UnityEngine;

public class EnemSpawner : MonoBehaviour
{
    [Header("Prefabs de los Enemigos")]
    public GameObject EnemyPrefab1; 
    public GameObject EnemyPrefab2; 

    [Header("Configuración del Generador")]
    public float spawnInterval = 3f;
    public int maxEnemies = 10;
    public float range = 5f;         

    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
      
            int totalEnemigos1 = FindObjectsByType<EnemyState>(FindObjectsSortMode.None).Length;
            int totalEnemigos2 = FindObjectsByType<EnemyState2>(FindObjectsSortMode.None).Length;

            int totalActual = totalEnemigos1 + totalEnemigos2;

            if (totalActual < maxEnemies)
            {
                
                int randomEnemy = Random.Range(0, 2);

                if (randomEnemy == 0)
                {
                    SpawnEnemy(EnemyPrefab1);
                }
                else
                {
                    SpawnEnemy(EnemyPrefab2);
                }
            }

           
            spawnTimer = spawnInterval;
        }
    }

    private void SpawnEnemy(GameObject enemyPrefabToClone)
    {
        if (enemyPrefabToClone == null) return;

        Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        Vector3 spawnOffset = randomDir * Random.Range(1f, range);
        Vector3 spawnPosition = transform.position + spawnOffset;

        
        Instantiate(enemyPrefabToClone, spawnPosition, Quaternion.identity);
    }
}