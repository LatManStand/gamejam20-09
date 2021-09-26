using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public bool starTranstion;
    public GameObject MainCamera;
    public GameObject transion_level_1;
    public GameObject transion_level_2;
    public GameObject transion_level_3;
    public GameObject transion_level_4;

    public GameObject backButton;
    public GameObject dialogueSystem;

    [Space(10)]
    [Header("Worlds levels")]
    public ClickableWorlLevel level_1;
    public ClickableWorlLevel level_2;
    public ClickableWorlLevel level_3;
    public ClickableWorlLevel level_4;

    // Start is called before the first frame update
    void Start()
    {
        starTranstion = false;
        dialogueSystem.SetActive(false);
        MainCamera.SetActive(true);
        transion_level_1.SetActive(false);
        transion_level_2.SetActive(false);
        transion_level_3.SetActive(false);
        transion_level_4.SetActive(false);
        backButton.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("new_game") == 1)
        {
            Dialogue1();
        }
    }

    public void goToLevel(int levelNumber)
    {
        starTranstion = true;
        Debug.Log("Se fue al nivel: " + levelNumber);
        activateTransition(levelNumber);
    }

    public void GoBackToMap ()
    {
        starTranstion = false;
        transion_level_1.SetActive(false);
        transion_level_2.SetActive(false);
        transion_level_3.SetActive(false);
        transion_level_4.SetActive(false);
        backButton.SetActive(false);
        MainCamera.SetActive(true);

        level_1.GoBackToMenu();
        level_2.GoBackToMenu();
        level_3.GoBackToMenu();
        level_4.GoBackToMenu();
        Debug.Log("Volvimos al mapa!");
    }

    private void activateTransition (int levelNumber)
    {
        MainCamera.SetActive(false);
        backButton.SetActive(true);
        switch (levelNumber)
        {
            case 1:
                transion_level_1.SetActive(true);
                break;
            case 2:
                transion_level_2.SetActive(true);
                break;
            case 3:
                transion_level_3.SetActive(true);
                break;
            case 4:
                transion_level_4.SetActive(true);
                break;
        }
    }

    public void goBack()
    {
        GameManager.instance.LoadScene("MainMenu");
    }

    void Dialogue1()
    {
        PlayerPrefs.SetInt("new_game", 0);
        PlayerPrefs.Save();
        dialogueSystem.SetActive(true);
        dialogueSystem.GetComponent<DialogueTrigger>().TriggerDialogue();
    }
}