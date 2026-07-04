using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform Player;

    [Header("Límites de la Casa (Primer Piso)")]
    public float minX = -12f;
    public float maxX = 12f;
    public float minY = -2f;
    public float maxY = 1f;

    void Update()
    {
        if (Player != null)
        {
            FollowPlayer();
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