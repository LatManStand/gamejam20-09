using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // IMPORTANT DATA
    public string language;
    public AudioSource audiosrc;

    public Scene lastScene;

    private void Awake()
    {
        Application.targetFrameRate = 300;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    //Called to start de game
    public void StartGame()
    {
        // INIT THE DATA
        setNewGame();

        // CREATE A NEW SAVE DATA
        SaveData();

        // LOAD THE GAME
        GameManager.instance.LoadScene("Map");
    }

    public void QuitGame()
    {
        SaveData();
        Application.Quit();
    }

    public void LoadScene(string nameLevel)
    {
        lastScene = SceneManager.GetActiveScene();
        if (nameLevel.Equals("Ending") || nameLevel.Equals("Credits"))
        {
            audiosrc.Stop();
        }

        SceneManager.LoadScene(nameLevel);
    }

    private IEnumerator LoadAsyncScene(string nameLevel)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nameLevel);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void SaveData()
    {
        // SAVE IMPORTANT DATA
        //PlayerPrefs.SetInt("helpedWolf" + slot, helpedWolf);

        //PlayerPrefs.Save();
    }


    private void setNewGame()
    {
        PlayerPrefs.SetInt("new_game", 1);
        Debug.Log(PlayerPrefs.GetInt("new_game"));

        PlayerPrefs.SetInt("puzzle_1.1", 1);
        PlayerPrefs.SetInt("puzzle_1.2", 0);
        PlayerPrefs.SetInt("puzzle_1.3", 0);
        PlayerPrefs.SetInt("puzzle_1.4", 0);

        PlayerPrefs.Save();
    }
}
