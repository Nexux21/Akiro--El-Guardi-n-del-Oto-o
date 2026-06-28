using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 15f;
    public float health = 100f;
    public float maxTime = 10;
    public int puntosDeAtaque = 10;
    public float rangoAtaque = 2f;
    public float currentTime;
    public bool isAbilityAblive = true;
    public GameObject BulletPrefab;
    public enemy enemyScript;

    void Start()
    {
        if (enemyScript == null)
        {
            enemyScript = FindAnyObjectByType<enemy>();
        }

    }


    void Update()
    {

        if (!isAbilityAblive)
        {
            TimerToDoSmt();
        }
        MovementPlayer();
        Shoot();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SimpleAttack();
        }


    }
    public void MovementPlayer()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        Vector3 dir = new Vector3(x, y, 0);
        dir.Normalize();

        if (dir != Vector3.zero)
            transform.position += dir * Speed * Time.deltaTime;
    }


    public void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position);
        direction.z = 0;
        direction.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPosition = transform.position;
            GameObject bullet = Instantiate(BulletPrefab, spawnPosition, Quaternion.identity);
            bullet.transform.up = direction; bullet.transform.up = direction;
        }
    }
    public void SimpleAttack()
    {
        if (isAbilityAblive && enemyScript != null)
        {
            float distancia = Vector3.Distance(transform.position, enemyScript.transform.position);
            if (distancia <= rangoAtaque)
            {
                Debug.Log("Ataque exitoso");
                enemyScript.RecibirDano(puntosDeAtaque);
            }
            else
            {
                Debug.Log("El enemigo está fuera de rango");
            }
            isAbilityAblive = false;
        }
    }
    
    public void TimerToDoSmt()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)
        {
            isAbilityAblive = true;
            currentTime = 0;
        }
    }
}



