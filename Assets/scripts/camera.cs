using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
       
        Vector3 desplazamiento = new Vector3(0, 0, -5);

       
        transform.position = Player.position + desplazamiento;
    }
}