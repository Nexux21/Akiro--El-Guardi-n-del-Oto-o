using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 15f;
    public float TimeAlive = 3;
    void Start()
    {
        Destroy(gameObject, TimeAlive);

        dir = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
        dir.Normalize();
    }
    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }
}