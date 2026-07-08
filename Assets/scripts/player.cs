using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Movimiento")]
    public float Velocidad = 7f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 movimiento;

    [Header("Ataque a Rango")]
    public GameObject BulletPrefab;
    public Transform PuntoDisparo;
    public float TiempoEntreDisparos = 0.2f;
    private float tiempoSiguienteDisparo = 0f;

    [Header("Estadísticas")]
    public float health = 100f;
    public float healthMaxima = 100f;

    [Header("UI de Vida")]
    public Game_Manager_Vida gameManagerVida;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (rb != null)
        {
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }

        ActualizarUIVida();
    }

    void Update()
    {
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.y = Input.GetAxisRaw("Vertical");

        if (movimiento.x > 0.1f) spriteRenderer.flipX = false;
        else if (movimiento.x < -0.1f) spriteRenderer.flipX = true;

        if (Input.GetMouseButton(0) && Time.time >= tiempoSiguienteDisparo)
        {
            Disparar();
            tiempoSiguienteDisparo = Time.time + TiempoEntreDisparos;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movimiento.normalized * Velocidad;
    }

    void Disparar()
    {
        if (BulletPrefab == null) return;

        Vector3 posicionOrigen = (PuntoDisparo != null) ? PuntoDisparo.position : transform.position;
        float angulo = spriteRenderer.flipX ? 180f : 0f;
        Quaternion rotacionBala = Quaternion.Euler(0, 0, angulo - 90f);

        Instantiate(BulletPrefab, posicionOrigen, rotacionBala);
    }

    public void TomarDaño(float cantidad)
    {
        health -= cantidad;
        health = Mathf.Clamp(health, 0, healthMaxima);

        ActualizarUIVida();

        if (health <= 0)
        {
            Morir();
        }
    }

    public void Curar(float cantidad)
    {
        health += cantidad;
        health = Mathf.Clamp(health, 0, healthMaxima);

        ActualizarUIVida();
    }

    void ActualizarUIVida()
    {
        if (gameManagerVida == null) return;

       
        float porcentaje = health / healthMaxima;
        int indiceCorazon = Mathf.RoundToInt(porcentaje * (gameManagerVida.lives.Length - 1));

        gameManagerVida.UpdateLives(indiceCorazon);
    }

    void Morir()
    {
        Debug.Log("El jugador ha muerto");
     
    }
}