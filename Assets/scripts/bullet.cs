using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 15f;
    public float TimeAlive = 3f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2"))
        {
            enemy scriptenemy = collision.gameObject.GetComponent<enemy>();

            if (scriptenemy != null)
            {
               
                scriptenemy.RecibirDano(10);

               
                Destroy(gameObject);
            }
        }
    }
}