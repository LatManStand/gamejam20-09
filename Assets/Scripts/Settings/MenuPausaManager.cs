using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPausaManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject menuSettings;
    public GameObject menuPausaPanel;

    [Space(10)]
    [Header("UI Buttons")] 
    public GameObject buttonOpenPausaPanel;

    [Space(10)]
    [Header("UI Sliders")]
    public GameObject sliderMusic;
    public GameObject sliderEffects;


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

    public void UI_ChangeMusicControl ()
    {
        GameManager.instance.setMusicControl(sliderMusic.GetComponent<Slider>().value);
    }

    public void UI_ChangeEffectsControl()
    {
        GameManager.instance.setEffecsControl(sliderEffects.GetComponent<Slider>().value);
    }
}
