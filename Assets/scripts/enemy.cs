using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject Target;
    public float Speed;
    public float radiusAttack;
    public float radiusMovement;

    void Start()
    {

    }

    void Update()
    {
        FollowTarget();
    }

    public void FollowTarget()
    {
        Vector3 dir = (Target.transform.position - transform.position).normalized;
        if (Vector3.Distance(Target.transform.position, dir) < radiusAttack)
        {

        }
        else
        {
            transform.position += dir * Speed * Time.deltaTime;

        }
    }
}
