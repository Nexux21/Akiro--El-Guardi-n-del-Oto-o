using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 15f;

    void Start()
    {

    }


    void Update()
    {
        MovementPlayer();
    }
    public void MovementPlayer()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");


        Vector3 dir = new Vector3(x, Y, 0);
        dir.Normalize();

        if (dir != Vector3.zero)
            transform.position += dir * Speed * Time.deltaTime;
    }
}

