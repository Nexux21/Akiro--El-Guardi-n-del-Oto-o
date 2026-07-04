using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public int Vida = 20; 
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
        
        if (Vida <= 0)
        {
            Destroy(gameObject);
            return;
        }

        FollowTarget();
        if (!isAbleToAttack)
        {
            TimerToDoSmt();
        }
    }

    public void FollowTarget()
    {
        Vector3 targetPos = Target.transform.position;
        Vector3 myPos = transform.position;

        float distance = Vector3.Distance(targetPos, myPos);

        if (distance < radiusAttack - 0.5f)
        {
            Vector3 escapeDirection = (myPos - targetPos).normalized;
            transform.position += escapeDirection * Speed * Time.deltaTime;
        }
        else if (distance >= radiusAttack && distance < radiusMovement)
        {
            Vector3 followDirection = (targetPos - myPos).normalized;
            transform.position += followDirection * Speed * Time.deltaTime;
        }
    }

    public void TimerToDoSmt()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            isAbleToAttack = true;
            currentTime = 0;
        }
    }
}