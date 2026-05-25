using UnityEngine;

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
