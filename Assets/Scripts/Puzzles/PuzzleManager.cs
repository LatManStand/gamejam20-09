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
    public GameObject puzzleCompletadoIMAGEN;

    public bool completado;

    public float nivel;
    [HideInInspector]
    public string puzzle;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            puzzleCompletadoIMAGEN.SetActive(false);
            puzzle = SceneManager.GetActiveScene().path;
            int aux = puzzle.IndexOf(".");
            //nivel = float.Parse(puzzle.Substring(aux + 1));
            nivel = float.Parse(puzzle.Substring(aux - 1, 3), CultureInfo.InvariantCulture);
            audioSource = GetComponent<AudioSource>();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Cursor.visible = false;
    }


    private void Update()
    {
        if (piezasColocadas == piezas && !completado)
        {
            completado = true;
            audioSource.Play();
            puzzleCompletadoIMAGEN.SetActive(true);
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
