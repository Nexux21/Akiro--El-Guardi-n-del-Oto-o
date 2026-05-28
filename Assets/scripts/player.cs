using UnityEngine;

public class player : MonoBehaviour
{
    // Mi variable para controlar la velocidad desde el Inspector
    public float speed = 10f;

    private Vector2 inputsVector;
    private Vector2 movementVector;

    void Update()
    {
        // Dividí mi lógica en funciones simples para cumplir con el Hito 2
        LeerTeclado();
        CalcularDireccion();
        MoverPersonaje();
    }

    // Mi función para capturar las entradas del teclado usando Input.GetAxis
    void LeerTeclado()
    {
        inputsVector.x = Input.GetAxisRaw("Horizontal");
        inputsVector.y = Input.GetAxisRaw("Vertical");
    }

    // Aquí proceso mi vector de movimiento y lo normalizo para las diagonales
    void CalcularDireccion()
    {
        if (inputsVector.magnitude > 1)
        {
            movementVector = inputsVector.normalized;
        }
        else
        {
            movementVector = inputsVector;
        }
    }

    // Mi función final que cambia la posición sumando el vector de desplazamiento
    void MoverPersonaje()
    {
        Vector3 desplazamiento = new Vector3(movementVector.x, movementVector.y, 0f);
        transform.position = transform.position + (desplazamiento * speed * Time.deltaTime);
    }
}