using UnityEngine;

public class bullet : MonoBehaviour
{
    public float VelocidadProyectil = 30f;
    public float TiempoVivo = 3f;
    public float DañoRango = 5f;

    void Start()
    {
        Destroy(gameObject, TiempoVivo);
    }

    private void OnTriggerEnter2D(Collider2D Colisionador)
    {
        if (Colisionador.CompareTag("Enemy"))
        {
            enemy ComponenteEnemigo = Colisionador.GetComponent<enemy>();
            if (ComponenteEnemigo != null)
            {
                ComponenteEnemigo.RecibirDano((int)DañoRango);
            }
            Destroy(gameObject);
            return;
        }

        if (Colisionador.CompareTag("Enemy2"))
        {
            enemy2 ComponenteEnemigo2 = Colisionador.GetComponent<enemy2>();
            if (ComponenteEnemigo2 != null)
            {
                ComponenteEnemigo2.Vida -= (int)DañoRango;
            }
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        transform.position += transform.up * VelocidadProyectil * Time.deltaTime;
    }
}