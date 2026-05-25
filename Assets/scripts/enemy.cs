using UnityEngine;

public class Enemy : MonoBehaviour
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
        if (Vector3.Distance(Target.transform.position, transform.position) < radiusMovement)
        {
            if (Vector3.Distance(Target.transform.position, transform.position) < radiusAttack)
            {
                Debug.Log("atacando >:l ");
            }
            else
            {
                transform.position += dir * Speed * Time.deltaTime;
            }
        }




    }
}
