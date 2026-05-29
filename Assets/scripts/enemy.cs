using UnityEngine;

public class enemy : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float enemySpeed = 5f;       // Mi velocidad que ya configuré en el Inspector
    public float rangoDeParada = 1f;    // Mi rango de parada de mi Inspector

    private Transform objetivoAkiro;     // Aquí guardaré la posición de mi jugador

    void Start()
    {
        // El enemigo buscará al gato de Scratch usando su etiqueta oficial
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");

        if (jugador != null)
        {
            objetivoAkiro = jugador.transform;
        }
        else
        {
            Debug.LogWarning("¡No encontré ningún objeto con el Tag 'Player'!");
        }
    }

    void Update()
    {
        // Si logré encontrar al jugador en la escena, ejecuto mi persecución
        if (objetivoAkiro != null)
        {
            PerseguirObjetivo();
        }
    }

    void PerseguirObjetivo()
    {
        // 1. Calculo la distancia entre mi posición y la del jugador
        float distancia = Vector2.Distance(transform.position, objetivoAkiro.position);

        // 2. Si estoy más lejos del rango permitido, me acerco usando vectores
        if (distancia > rangoDeParada)
        {
            // Calculo el siguiente paso en línea recta hacia mi Transform objetivo
            Vector3 siguientePosicion = Vector2.MoveTowards(
                transform.position,
                objetivoAkiro.position,
                enemySpeed * Time.deltaTime
            );

            // Aplico la traslación directa que me pide mi profesor
            transform.position = siguientePosicion;
        }
    }
}