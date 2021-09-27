using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;
    public int piezas;
    public int piezasColocadas;

    public float nivel;
    [HideInInspector]
    public string puzzle;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            puzzle = SceneManager.GetActiveScene().path;
            Cursor.visible = false;
            int aux = puzzle.IndexOf(".");
            //nivel = float.Parse(puzzle.Substring(aux + 1));
            nivel = float.Parse(puzzle.Substring(aux - 1, 3), CultureInfo.InvariantCulture);
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
            GameManager.instance.PuzzleComplete(nivel);
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
