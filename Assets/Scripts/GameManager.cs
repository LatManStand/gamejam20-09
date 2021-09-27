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
    public AudioSource music;
    public UnityEngine.Audio.AudioMixer mixer;

    public Scene lastScene;
    public GameObject endScreen;

    private bool isGamePaused;

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
        isGamePaused = false;
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

        // LOAD THE INITIAL PUZZLE
        //GameManager.instance.LoadScene("Scenes/Puzzles/Level_1/Puzzle_1.1");
        GameManager.instance.LoadScene("Map");
    }

    public void ContinueGame()
    {
        // GET THE DATA
        setMusicControl(PlayerPrefs.GetFloat("musicVol"));
        setEffecsControl(PlayerPrefs.GetFloat("SFXVol"));

        // LOAD THE INITIAL PUZZLE
        GameManager.instance.LoadScene("Scenes/Puzzles/Level_1/Puzzle_1.1");
    }

    public void PauseGame()
    {
        //Any related with pause game
        isGamePaused = true;
    }

    public void ResumenGame()
    {
        //Any related with pause game
        isGamePaused = false;
    }

    public bool isPause()
    {
        return isGamePaused;
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
            //music.Stop();
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

        PlayerPrefs.Save();
    }

    private void setNewGame()
    {
        PlayerPrefs.SetInt("new_game", 1);
        Debug.Log(PlayerPrefs.GetInt("new_game"));
        PlayerPrefs.SetFloat("musicVol", -0.03299108f);
        PlayerPrefs.SetFloat("SFXVol", -0.03299108f);

        PlayerPrefs.SetInt("Puzzle_1.1", 1);
        PlayerPrefs.SetInt("Puzzle_1.2", 1);
        PlayerPrefs.SetInt("Puzzle_1.3", 1);

        PlayerPrefs.SetInt("Puzzle_2.1", 1);
        PlayerPrefs.SetInt("Puzzle_2.2", 1);
        PlayerPrefs.SetInt("Puzzle_2.3", 1);

        PlayerPrefs.SetInt("Puzzle_3.1", 1);
        PlayerPrefs.SetInt("Puzzle_3.2", 1);

        PlayerPrefs.SetInt("Puzzle_4.3", 1);
        PlayerPrefs.SetInt("Puzzle_4.3", 1);
    }

    public void PuzzleComplete(float puzzle)
    {
        //Instantiate(endScreen);
        PlayerPrefs.SetInt("Puzzle_" + puzzle + 0.1, 1);
        Invoke(nameof(LoadSceneMap), 3f);
    }

    public void LoadSceneMap()
    {
        LoadScene("Map");
    }

    public void setMusicControl(float value)
    {
        if (value == 0)
        {
            return;
        }

        var newVolumen = Mathf.Log10(value) * 20;
        mixer.SetFloat("musicVol", newVolumen);
        PlayerPrefs.SetFloat("musicVol", newVolumen);
    }

    public void setEffecsControl(float value)
    {
        if (value == 0)
        {
            return;
        }

        var newVolumen = Mathf.Log10(value) * 20;
        mixer.SetFloat("SFXVol", newVolumen);
        PlayerPrefs.SetFloat("SFXVol", newVolumen);
    }
}
