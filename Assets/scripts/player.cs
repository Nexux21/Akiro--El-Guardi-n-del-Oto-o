using UnityEngine;
public class player : MonoBehaviour
{
    // Mi variable para controlar la velocidad desde el Inspector
    public float speed = 10f;

    private Vector2 inputsVector;
    private Vector2 movementVector;

    void Update()
    {
        // Dividí mi lógica en funciones simples 
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
public class ejercicio : MonoBehaviour
{
    public float HorizontalMovement;
    public float VerticalMovement;
    public float Speed;

    void Start()
    {

    }


    void Update()
    {


        MovementPlayer();


    }
    public void MovementPlayer()

    {
        Debug.Log("player try to move");

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, y, 0);
        dir.Normalize();

        if (dir != Vector3.zero)
            transform.position += dir * Speed * Time.deltaTime;



    }
}