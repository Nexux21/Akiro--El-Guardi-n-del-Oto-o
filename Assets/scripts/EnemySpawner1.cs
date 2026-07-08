using UnityEngine;

public class EnemySpawner1 : MonoBehaviour
{
    public GameObject EnemigoPrefab;
    public string TagEnemigo = "Enemy";

    public float GeneradorTiempo = 0.5f;
    public int MaximodeGeneraciones = 7;
    public int GeneracionesIniciales = 3;

    public float RangoX = 3f;          
    public float DistanciaMinima = 1f; 

    private float tiempoActual;

    void Start()
    {
        tiempoActual = GeneradorTiempo;

        int i = 0;
        while (i < GeneracionesIniciales)
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
        if (EnemigoPrefab == null) return;

        
        int intentos = 0;
        while (intentos < 10)
        {
            float x = transform.position.x + Random.Range(-RangoX, RangoX);
            float y = transform.position.y; 
            Vector3 posicion = new Vector3(x, y, transform.position.z);

            if (!HayEnemigoCerca(posicion))
            {
                Instantiate(EnemigoPrefab, posicion, Quaternion.identity);
                return;
            }

            intentos++;
        }
    }

    
    private bool HayEnemigoCerca(Vector3 posicion)
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(TagEnemigo);
        for (int i = 0; i < enemigos.Length; i++)
        {
            float distancia = Vector3.Distance(enemigos[i].transform.position, posicion);
            if (distancia < DistanciaMinima)
            {
                return true;
            }
        }
        return false;
    }
}