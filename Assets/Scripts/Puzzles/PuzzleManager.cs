using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;
    public int piezas;
    public int piezasColocadas;

    public string nivel;
    public string puzzle;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (piezasColocadas == piezas)
        {
            // ALEX, AQUI ACABA EL NIVEL

            //GameManager.instance.
        }
    }



    public void UI_GoBackToMap()
    {
        GameManager.instance.SaveData();
        GameManager.instance.LoadScene("Map");
    }
}
