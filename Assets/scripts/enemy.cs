using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject Target;
    public float Speed;
    public float radiusAttack;
    public float radiusMovement;
    public float damage;
    public bool isAbleToAttack = true;
    public float maxTime = 2f;
    public float currentTime;
    void Start()
    {

    }

    void Update()
    {
        FollowTarget();
        if (isAbleToAttack)
        {
            TimerToDoSmt();
        }
    }

    public void FollowTarget()
    {
        Vector3 targetPos = Target.transform.position;
        Vector3 myPos = transform.position;

        Vector3 direction = (targetPos - myPos).normalized;
        if (Vector3.Distance(targetPos, myPos) > radiusMovement)
        {
            if (Vector3.Distance(targetPos, myPos) < radiusAttack)
            {
                if (isAbleToAttack)
                    Debug.Log("dañandote");
                Target.GetComponent<Player>().health -= damage;
                isAbleToAttack = false;
            }
            else
            {

                transform.position += direction * Speed * Time.deltaTime;
            }
        }
    }
    public void TimerToDoSmt()
    {        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
                     isAbleToAttack = true;
            currentTime = 0;
        }
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
