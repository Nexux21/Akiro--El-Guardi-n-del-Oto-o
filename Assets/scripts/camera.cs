using UnityEngine;

public class camera : MonoBehaviour
{
    // Mi variable expuesta para enlazar la posición de mi jugador
    private Transform objetivoJugador;

    [Header("Configuración de Desplazamiento")]
    public float suavizado = 5f; // Qué tan rápido la cámara alcanza al jugador
    public float distanciaZ = -10f; // La profundidad obligatoria en 2D para no perder la vista

    void Start()
    {
        // Busco automáticamente al jugador por su etiqueta al iniciar
        GameObject jugador = GameObject.FindGameObjectWithTag("Player");
        if (jugador != null)
        {
            objetivoJugador = jugador.transform;
        }
    }

    // Uso LateUpdate para que el movimiento de la cámara sea suave y vaya después del jugador
    void LateUpdate()
    {
        if (objetivoJugador != null)
        {
            SeguirPersonaje();
        }
    }

    void SeguirPersonaje()
    {
        // 1. Creo el vector de destino tomando la posición X e Y del jugador, pero manteniendo la Z de la cámara
        Vector3 posicionDestino = new Vector3(objetivoJugador.position.x, objetivoJugador.position.y, distanciaZ);

        // 2. Interpolación lineal vectorial (Lerp) para que el movimiento sea fluido y no tosco
        Vector3 posicionSuave = Vector3.Lerp(transform.position, posicionDestino, suavizado * Time.deltaTime);

        // 3. Aplico la nueva posición a mi Transform
        transform.position = posicionSuave;
    }
}