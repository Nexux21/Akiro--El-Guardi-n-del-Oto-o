using UnityEngine;

public class player : MonoBehaviour
{
    [Header("Movimiento")]
    public float Velocidad = 5f;

    [Header("Ataque a Rango")]
    public GameObject BulletPrefab;
    public Transform PuntoDisparo;
    public float TiempoEntreDisparos = 0.2f;
    private float tiempoSiguienteDisparo = 0f;

    void Update()
    {
        MecanicaMovimiento();
        MecanicaRotacionMouse();

        if (Input.GetMouseButton(0) && Time.time >= tiempoSiguienteDisparo)
        {
            Disparar();
            tiempoSiguienteDisparo = Time.time + TiempoEntreDisparos;
        }
    }

    void MecanicaMovimiento()
    {
        float moverX = Input.GetAxisRaw("Horizontal");
        float moverY = Input.GetAxisRaw("Vertical");

        Vector3 direccion = new Vector3(moverX, moverY, 0).normalized;
        transform.position += direccion * Velocidad * Time.deltaTime;
    }

    void MecanicaRotacionMouse()
    {
        Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direccionMouse = posicionMouse - transform.position;
        direccionMouse.z = 0;

        if (direccionMouse.magnitude > 0.1f)
        {
            float angulo = Mathf.Atan2(direccionMouse.y, direccionMouse.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angulo - 90f);
        }
    }

    void Disparar()
    {
        if (BulletPrefab == null) return;

        Vector3 posicionOrigen = (PuntoDisparo != null) ? PuntoDisparo.position : transform.position;

        Instantiate(BulletPrefab, posicionOrigen, transform.rotation);
    }
}