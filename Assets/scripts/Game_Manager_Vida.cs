using UnityEngine;
using UnityEngine.UI;

public class Game_Manager_Vida : MonoBehaviour
{
    [Header("Sprites de vida (0 = vacío, 3 = lleno)")]
    public Sprite[] lives;

    [Header("Imagen que muestra el corazón actual")]
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
}







