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
        transform.position = new Vector3(
            Player.position.x,
            Player.position.y,
            -5
        );
    }
}