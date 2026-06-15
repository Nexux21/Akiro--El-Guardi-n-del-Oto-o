using UnityEngine;

public enum EnemyEnum
{ 
    None,
    Idle,
    Follow,
    Attack,
}


public class EnemyState : MonoBehaviour
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
    public bool estaMuerto = false;
    public EnemyEnum type;
    void Start()
    {
        if (Target == null)
        {
            Target = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        Vector3 targetPos = Target.transform.position;
        Vector3 myPos = transform.position;

        switch (type)
        {
            case EnemyEnum.None:
                break;
            case EnemyEnum.Idle:
                if (Vector3.Distance(targetPos, myPos) < radiusMovement)
                    type = EnemyEnum.Follow;
                break;
            case EnemyEnum.Follow:
                Vector3 direction = (targetPos - myPos).normalized;
                transform.position += direction * Speed * Time.deltaTime;


                break;
            case EnemyEnum.Attack:
                if (!isAbleToAttack)
                {
                   
                }
                break;
            }
            if (estaMuerto) return;
        if (Target == null) return;
        FollowTarget();
        if (!isAbleToAttack)
        {
            TimerT();
        }
    }
    


    public void RecibirDano(int cantidad)
    {
        if (estaMuerto) return;
        Vida -= cantidad;
        Debug.Log(gameObject.name + " ha recibido " + cantidad + " de daño. Vida restante: " + Vida);
        if (Vida <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        estaMuerto = true;
        Debug.Log(gameObject.name + " ha muerto.");
        Destroy(gameObject);
    }

    public void FollowTarget()
    {
        if (estaMuerto) return;
        Vector3 targetPos = Target.transform.position;
        Vector3 myPos = transform.position;
        float distancia = Vector3.Distance(targetPos, myPos);

        Vector3 direction = (targetPos - myPos).normalized;
        if (distancia > radiusMovement)
        {
            if (distancia < radiusAttack)
            {
                if (isAbleToAttack)
                {
                    Debug.Log("dañandote");
                    Target.GetComponent<Player>().health -= damage;
                    isAbleToAttack = false;
                }
            }
            else
            {

                transform.position += direction * Speed * Time.deltaTime;
            }
        }
    }
    public void TimerT()
    {
        if (estaMuerto) return;
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            isAbleToAttack = true;
            currentTime = 0;
        }
        Vector3 dir = (Target.transform.position - transform.position).normalized;

        if (Vector3.Distance(Target.transform.position, transform.position) < radiusAttack)

        {

        }
        else
        {
            transform.position += dir * Speed * Time.deltaTime;

        }
    }
}