using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Requisito: Variable constante 
    public const float VELOCIDAD_ROTACION = 5f;

    // Requisito: Variable estática para el puntaje 
    public static int enemigosDerrotados = 0;

    public GameObject prefabProyectil;
    public Transform puntoDisparo;

    void Update()
    {
        MoverPersonaje(); // Función requerida 

        if (Input.GetButtonDown("Fire1")) // Click izquierdo
        {
            Disparar(); // Función requerida 
        }
    }

    void MoverPersonaje()
    {
        // Requisito: Uso de vectores para rotar hacia el mouse 
        Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direccion = (Vector2)posicionMouse - (Vector2)transform.position;

        // El jugador "mira" hacia el mouse
        transform.up = direccion;
    }

    void Disparar()
    {
        // Requisito: Disparar proyectil usando vectores 
        Instantiate(prefabProyectil, puntoDisparo.position, transform.rotation);
    }

    // Requisito: Función parametrizada que retorna un valor 
    public int CalcularPuntajeFinal(int bonificacion)
    {
        return enemigosDerrotados + bonificacion;
    }
}