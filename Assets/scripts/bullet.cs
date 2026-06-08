using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 15f;
    public float TimeAlive = 3;
    void Start()
    {
        Destroy(gameObject, TimeAlive);
    }
    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }
}