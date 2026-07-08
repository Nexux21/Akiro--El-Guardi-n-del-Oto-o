using UnityEngine;
public class camera : MonoBehaviour
{
    public Transform Player;

    [Header("Bordes reales del nivel (en unidades del mundo)")]
    public float nivelMinX = -14f;
    public float nivelMaxX = 14f;
    public float nivelMinY = -3f;
    public float nivelMaxY = 2f;

    [Header("Límites calculados para el centro de la camara")]
    public float minX = -12f;
    public float maxX = 12f;
    public float minY = -2f;
    public float maxY = 1f;

    void Start()
    {
        CalcularLimites();
    }

    void Update()
    {
        if (Player != null)
        {
            FollowPlayer();
        }
    }

    
    public void CalcularLimites()
    {
        Camera cam = GetComponent<Camera>();
        if (cam == null) return;

        float mitadAlto = cam.orthographicSize;
        float mitadAncho = mitadAlto * cam.aspect;

        minX = nivelMinX + mitadAncho;
        maxX = nivelMaxX - mitadAncho;
        minY = nivelMinY + mitadAlto;
        maxY = nivelMaxY - mitadAlto;

        
        if (minX > maxX)
        {
            float centroX = (nivelMinX + nivelMaxX) / 2f;
            minX = centroX;
            maxX = centroX;
        }
        if (minY > maxY)
        {
            float centroY = (nivelMinY + nivelMaxY) / 2f;
            minY = centroY;
            maxY = centroY;
        }
    }

    public void FollowPlayer()
    {
        float targetX = Player.position.x;
        float targetY = Player.position.y;

        if (targetX < minX)
        {
            targetX = minX;
        }
        if (targetX > maxX)
        {
            targetX = maxX;
        }
        if (targetY < minY)
        {
            targetY = minY;
        }
        if (targetY > maxY)
        {
            targetY = maxY;
        }

        transform.position = new Vector3(targetX, targetY, -5f);
    }
}