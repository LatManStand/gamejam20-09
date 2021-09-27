using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;
    public int piezas;
    public int piezasColocadas;

    public string nivel;
    [HideInInspector]
    public string puzzle;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            puzzle = SceneManager.GetActiveScene().path;
            Cursor.visible = false;
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


    public void ReloadScene()
    {
        GameManager.instance.LoadScene(puzzle);
    }


    public void UI_GoBackToMap()
    {
        GameManager.instance.SaveData();
        GameManager.instance.LoadScene("Map");
    }
}
