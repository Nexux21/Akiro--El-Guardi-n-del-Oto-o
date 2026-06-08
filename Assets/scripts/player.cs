using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 15f;
    public float health;
    public float maxTime = 10;
    public float currentTime;
    public bool isAbilityAblive = true;
    public GameObject BulletPrefab;

    void Start()
    {

    }


    void Update()
    {

        if (!isAbilityAblive)
        {
            TimerToDoSmt();
        }
        MovementPlayer();
        Shoot();


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


    public void Shoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = (mousePos - transform.position);
        direction.z = 0;
        direction.Normalize();

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPosition = transform.position + (transform.up * 1.5f);
            GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.up = direction;
        }
    }
    public void SimpleAttack()
    {
        if (isAbilityAblive)
        {
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



