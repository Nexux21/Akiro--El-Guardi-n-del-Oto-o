using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Movimiento Lateral")]
    public float Velocidad = 7f;
    private float moverX;

    [Header("Salto")]
    public float FuerzaSalto = 12f;
    public Transform DetectorSuelo;
    public LayerMask CapaSuelo;
    private bool tocandoSuelo;
    public float RadioDeteccion = 0.2f;

    [Header("Ataque a Rango")]
    public GameObject BulletPrefab;
    public Transform PuntoDisparo;
    public float TiempoEntreDisparos = 0.2f;
    private float tiempoSiguienteDisparo = 0f;

    public float health = 100f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void Update()
    {
        moverX = Input.GetAxisRaw("Horizontal");

        if (moverX > 0.1f) spriteRenderer.flipX = false;
        else if (moverX < -0.1f) spriteRenderer.flipX = true;

        if (DetectorSuelo != null)
        {
            tocandoSuelo = Physics2D.OverlapCircle(DetectorSuelo.position, RadioDeteccion, CapaSuelo);
        }

        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow)) && tocandoSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, FuerzaSalto);
        }

        if (Input.GetMouseButton(0) && Time.time >= tiempoSiguienteDisparo)
        {
            Disparar();
            tiempoSiguienteDisparo = Time.time + TiempoEntreDisparos;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moverX * Velocidad, rb.linearVelocity.y);
    }

    void Disparar()
    {
        if (BulletPrefab == null) return;

        Vector3 posicionOrigen = (PuntoDisparo != null) ? PuntoDisparo.position : transform.position;

        float angulo = spriteRenderer.flipX ? 180f : 0f;
        Quaternion rotacionBala = Quaternion.Euler(0, 0, angulo - 90f);

        Instantiate(BulletPrefab, posicionOrigen, rotacionBala);
    }
}