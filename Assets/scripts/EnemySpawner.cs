using UnityEngine;
using System.Collections.Generic; // Para usar Listas 

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemigoPrefab;
    public Transform player;
    public float distanciaActivacion = 10f;

    // Requisito: Implementación de una lista 
    public List<string> nombresEnemigos = new List<string> { "Hormiga Roja", "Hormiga Negra" };

    void Update()
    {
        // Requisito: Medir distancia para activar comportamiento 
        float distancia = Vector2.Distance(transform.position, player.position);

        // Requisito: Estructura IF 
        if (distancia < distanciaActivacion)
        {
            // Aquí podrías poner un temporizador para instanciar enemigos
            Debug.Log("Spawner Activo: El jugador está cerca.");
        }
    }

    void GenerarDecoracion()
    {
        // Requisito: Bucle FOR 
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Creando migaja decorativa número: " + i);
        }
    }
}