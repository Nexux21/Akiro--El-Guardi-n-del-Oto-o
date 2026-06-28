using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemigoPrefab;
    public GameObject EnemigoPrefab2;
    public float GeneradorTiempo = 0.5f;
    public float Rango = 1.2f;
    public int MaximodeGeneraciones = 7;

    private float tiempoActual;

    void Start()
    {
        tiempoActual = GeneradorTiempo;

        int i = 0;
        while (i < 3)
        {
            GeneradorEnemigo();
            i++;
        }
    }

    void Update()
    {
        MecanicaTiempo();
    }

    public void MecanicaTiempo()
    {
        int enemigosActuales = GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Enemy2").Length;
        if (enemigosActuales >= MaximodeGeneraciones)
        {
            return;
        }

        tiempoActual -= Time.deltaTime;
        if (tiempoActual < 0)
        {
            GeneradorEnemigo();
            tiempoActual = 0.5f;
        }
    }

    public void GeneradorEnemigo()
    {
        Vector3 DirAleatorio = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        Vector3 LargoTotalDireccion = DirAleatorio * Random.Range(0.5f, Rango);

     
        bool esElPrimero = Random.value > 0.5f;
        GameObject prefabAEleccionar = esElPrimero ? EnemigoPrefab : EnemigoPrefab2;

        if (prefabAEleccionar == null) return;

        GameObject enemigo = Instantiate(prefabAEleccionar, transform.position, Quaternion.identity);
        enemigo.transform.position += LargoTotalDireccion;

      
        if (esElPrimero)
        {
            
            enemigo.transform.localScale = new Vector3(5.0f, 5.0f, 5.0f);
        }
        else
        {
            
            enemigo.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        }
    }
}