using UnityEngine;

public class EnemSpawner : MonoBehaviour 
{
    public GameObject EnemyPrefab;
    public float spawnTimer = 3f;
    public float range;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerMechanic();
    }

    public void TimerMechanic()
    {
        spawnTimer = 3;
    }



public void SpawnEnemy()
{

}
}