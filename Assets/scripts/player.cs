using UnityEngine;

public class ejercicio : MonoBehaviour
{
    public GameObject target;
    public float HorizontalMovement;
    public float VerticalMovement;
    public float Speed;
    public float smoothTime = 0.15f;
    public Vector3 offset = new Vector3(0,0,-10);

    private Vector3 velocity = Vector3.zero;

    void Start()
    {

    }


    void Update()
    {


        MovementPlayer();
        FollowTarget();


    }

    public void FollowTarget()
    {
        if (target != null);
        
        Vector3 targetPosition = target.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);



    }

    public void MovementPlayer()

    {
        Debug.Log("player try to move");

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, 0);
        dir.Normalize();

        if (dir != Vector3.zero)
            transform.position += dir * Speed * Time.deltaTime;



    }
}
