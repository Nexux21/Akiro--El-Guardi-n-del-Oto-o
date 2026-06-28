using UnityEngine;

public class bullet : MonoBehaviour
{
    public float Speed = 15f;
    public float TimeAlive = 3f;

    void Start()
    {
        Destroy(gameObject, TimeAlive);
    }

    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }

        if (collision.gameObject.CompareTag("Enemy2") || collision.gameObject.CompareTag("enemy2"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            return;
        }
    }
}
