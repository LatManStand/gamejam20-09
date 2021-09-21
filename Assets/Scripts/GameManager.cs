using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int slot;

    // IMPORTANT DATA

    public string language;
    public bool isCargarPartida;


    public bool hasHorse = false;
    public bool hasToothbrush = false;
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
        isCargarPartida = false;
    }
    public void setIsCargarPartida(bool value)
    {
        isCargarPartida = value;
    }

    public bool getIsCargarPartida()
    {
        return isCargarPartida;
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    //Called to start de game
    public void StartGame(int _slot)
    {
        slot = _slot;
        // IMPORTANT DATA

        SaveData();

        GameManager.instance.LoadScene("IntroGame");
    }

    public void QuitGame()
    {
        SaveData();
        Application.Quit();
    }

    public void LoadScene(string nameLevel)
    {
        lastScene = SceneManager.GetActiveScene();
        if (nameLevel.Equals("Ending") || nameLevel.Equals("Creditos"))
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

        PlayerPrefs.Save();
    }

    public void setSlot(int _slot)
    {
        slot = _slot;
    }

    public void LoadData(int _slot)
    {
        slot = _slot;
        // helpedWolf = PlayerPrefs.GetInt("helpedWolf" + helpedWolf);
    }

    public int existeSlotPartidaGuardada(int _slot)
    {
        return PlayerPrefs.GetInt("Game" + _slot);
    }

    public int getDiaPartidaGuardada(int _slot)
    {
        return PlayerPrefs.GetInt("Game" + _slot);
    }

    public void setLanguage(string lg)
    {
        this.language = lg;
        LoadScene("MainMenu");
    }
}
