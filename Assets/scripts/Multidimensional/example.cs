using UnityEngine;

public class Example : MonoBehaviour 
{

    public string[,] TiposYugioh = new string[2, 2]
    {
        {"Demonio", "Angel"},
        {"Mago", "Dragon"}
    };

    public string[][] MultiIrregular = new string[3][];

    void Start()
    {
        MultiIrregular[0] = new string[3] { "hola", "pedro", "manolo" };
        MultiIrregular[1] = new string[1] { "hola" };
        MultiIrregular[2] = new string[5] { "1", "1", "1", "1", "1" };

        MostarTablaMultidimensional(TiposYugioh);
    }

   
    public void MostarTablaMultidimensional(string[,] matriz)
    {
       
        for (int fila = 0; fila < matriz.GetLength(0); fila++)
        {
            for (int col = 0; col < matriz.GetLength(1); col++)
            {
                
                string value = matriz[fila, col];
                Debug.Log($"Fila {fila}, Columna {col}: {value}");
            }
        }
    } 
    void Update()
    {

    }
}