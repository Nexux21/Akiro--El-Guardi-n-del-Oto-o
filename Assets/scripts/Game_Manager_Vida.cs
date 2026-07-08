using UnityEngine;
using UnityEngine.UI;
public class Game_Manager_Vida : MonoBehaviour
{


    public Sprite[] lives;
    public Image livesImageDisplay;
    

    public void UpdateLives(int currentLives)
    {
        if (currentLives < 0 || currentLives >= lives.Length)
        {
            Debug.LogWarning("currentLives fuera de rango: " + currentLives);
            return;
        }

        livesImageDisplay.sprite = lives[currentLives];
    }

    void Update()
    {
        
    }
}
