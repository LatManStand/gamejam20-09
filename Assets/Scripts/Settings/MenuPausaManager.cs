using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausaManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject menuSettings;
    public GameObject menuPausaPanel;

    [Space(10)]
    [Header("UI Buttons")] 
    public GameObject buttonOpenPausaPanel;

    private void Start()
    {
        buttonOpenPausaPanel.SetActive(true);
        menuSettings.SetActive(false);
        menuPausaPanel.SetActive(false);
    }

    // -------------------- UI Methods -----------------
    public void UI_OpenPausagPanel()
    {
        menuPausaPanel.SetActive(true);
        buttonOpenPausaPanel.SetActive(false);
        GameManager.instance.PauseGame();
    }
    public void UI_ClosePausaPanel()
    {
        buttonOpenPausaPanel.SetActive(true);
        menuPausaPanel.SetActive(false);
        GameManager.instance.ResumenGame();
    }

    public void UI_OpenSettingsPanel()
    {
        menuSettings.SetActive(true);
        menuPausaPanel.SetActive(false);
    }

    public void UI_CloseSettingsPanel()
    {
        menuPausaPanel.SetActive(true);
        menuSettings.SetActive(false);
    }

    public void UI_GoToMenu()
    {
        GameManager.instance.SaveData();
        GameManager.instance.ResumenGame();
        GameManager.instance.LoadScene("MainMenu");
    }
}
