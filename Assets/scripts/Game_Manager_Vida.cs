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







/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public Image rellenoBarraVida;
    private PlayerController playerController;
    private float vidaMaxima;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        vidaMaxima = playerController.vida;
    }

    // Update is called once per frame
    void Update()
    {
        rellenoBarraVida.fillAmount = playerController.vida / vidaMaxima;
    }
}
