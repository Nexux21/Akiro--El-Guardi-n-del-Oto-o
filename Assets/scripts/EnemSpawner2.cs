using UnityEngine;

public class EnemySpawner_Enemigo2 : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject EnemigoPrefab2;
    public string TagEnemigo = "Enemy2";

    [Header("Tiempos")]
    public float GeneradorTiempo = 0.5f;
    public int MaximodeGeneraciones = 7;
    public int GeneracionesIniciales = 3;

    [Header("Rango horizontal de spawn")]
    public float RangoX = 3f;

    [Header("Deteccion de suelo")]
    public LayerMask CapaSuelo;
    public float AlturaRaycast = 10f;
    public float OffsetSueloY = 0f;

    private float tiempoActual;

    void Start()
    {
        tiempoActual = GeneradorTiempo;
        for (int i = 0; i < GeneracionesIniciales; i++)
        {
            GeneradorEnemigo();
        }
    }

    void Update()
    {
        MecanicaTiempo();
    }

    public void MecanicaTiempo()
    {
        int enemigosActuales = GameObject.FindGameObjectsWithTag(TagEnemigo).Length;
        if (enemigosActuales >= MaximodeGeneraciones)
        {
            return;
        }

        tiempoActual -= Time.deltaTime;
        if (tiempoActual < 0)
        {
            GeneradorEnemigo();
            tiempoActual = GeneradorTiempo;
        }
    }

    public void GeneradorEnemigo()
    {
        if (EnemigoPrefab2 == null) return;

        float offsetX = Random.Range(-RangoX, RangoX);
        float x = transform.position.x + offsetX;

        Vector2 origen = new Vector2(x, transform.position.y + AlturaRaycast);
        RaycastHit2D hit = Physics2D.Raycast(origen, Vector2.down, AlturaRaycast * 2f, CapaSuelo);

        Vector3 posicionFinal;
        if (hit.collider != null)
        {
            posicionFinal = new Vector3(x, hit.point.y + OffsetSueloY, transform.position.z);
        }
        else
        {
            posicionFinal = new Vector3(x, transform.position.y + OffsetSueloY, transform.position.z);
        }

        Instantiate(EnemigoPrefab2, posicionFinal, Quaternion.identity);
    }
}