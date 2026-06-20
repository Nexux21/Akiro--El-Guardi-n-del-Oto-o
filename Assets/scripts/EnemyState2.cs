using UnityEngine;

public enum Enemy2Enum
{
    None,
    Idle,
    escape,
    Attack,
}

public class EnemyState2 : MonoBehaviour
{

    public Enemy2Enum type = Enemy2Enum.Idle;

    [Header("Configuración")]
    public GameObject Target;
    public float Speed;
    public float damage; 

    [Header("Rangos de la IA")]
    public float radiusAttack;
    public float radiusMovement;

    [Header("Temporizador")]
    public bool isAbleToAttack = true;
    public float maxTime = 2f;
    public float currentTime;

    void Start()
    {
        
        if (Target == null)
        {
            Target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
    
        if (Target == null) return;

        Vector3 targetPos = Target.transform.position;
        Vector3 myPos = transform.position;
        float distance = Vector3.Distance(targetPos, myPos);

       
        if (!isAbleToAttack)
        {
            TimerToDoSmt();
        }

      
        switch (type)
        {
            case Enemy2Enum.None:
                break;

            case Enemy2Enum.Idle:
           
                if (distance < radiusMovement)
                {
                    type = Enemy2Enum.escape;
                }
                break;

            case Enemy2Enum.escape:
           
                FollowTarget();

            
                if (distance >= radiusMovement)
                {
                    type = Enemy2Enum.Idle;
                }
            
                else if (distance <= radiusAttack)
                {
                    type = Enemy2Enum.Attack;
                }
                break;

            case Enemy2Enum.Attack:
           
                FollowTarget();

            
                if (isAbleToAttack && distance >= (radiusAttack - 0.5f) && distance <= radiusAttack)
                {
                    Debug.Log("Enemigo 2 te dispara a distancia");
              
                    isAbleToAttack = false;
                }

                if (distance > radiusMovement)
                {
                    type = Enemy2Enum.Idle;
                }
                else if (distance > radiusAttack || distance < (radiusAttack - 0.5f))
                {
                    type = Enemy2Enum.escape;
                }
                break;
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
