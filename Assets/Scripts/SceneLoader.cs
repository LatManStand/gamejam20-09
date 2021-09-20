using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public SceneLoader instance;

    public bool isSettingsOpen = false;

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


    public void LoadSceneName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadSceneIndex(int number)
    {
        SceneManager.LoadScene(number);
    }

    public void LoadSettings()
    {
        if (!isSettingsOpen)
        {
            SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
            isSettingsOpen = true;
        }
        else
        {
            UnloadSettings();
        }
    }

    public void UnloadSettings()
    {
        SceneManager.UnloadSceneAsync(3);
        isSettingsOpen = false;
    }
}
