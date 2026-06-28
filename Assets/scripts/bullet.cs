using UnityEngine;

public class bullet : MonoBehaviour
{
    public float VelocidadProyectil = 3f;
    public float TiempoVivo = 3f;
    public float DañoRango = 5f;

    void Start()
    {
        Destroy(gameObject, TiempoVivo);
    }

    private void OnTriggerEnter2D(Collider2D Colisionador)
    {
  
        if (Colisionador.CompareTag("Enemy") || Colisionador.CompareTag("enemy"))
        {
            enemy ComponenteEnemigo = Colisionador.GetComponent<enemy>();
            if (ComponenteEnemigo != null)
            {
                // Aquí puedes restar la vida si tu script 'enemy' tiene una variable de salud
                // ComponenteEnemigo.VidaEnemigo -= DañoRango; 
            }
            Destroy(gameObject);
            return;
        }

     
        if (Colisionador.CompareTag("Enemy2") || Colisionador.CompareTag("enemy2"))
        {
            enemy2 ComponenteEnemigo2 = Colisionador.GetComponent<enemy2>();
            if (ComponenteEnemigo2 != null)
            {
                
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