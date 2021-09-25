using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{

    public bool starTranstion;
    public GameObject MainCamera;
    public GameObject transion1;

    public GameObject dialogueSystem;

    // Start is called before the first frame update
    void Start()
    {
        starTranstion = false;
        dialogueSystem.SetActive(false);
        MainCamera.SetActive(true);
        transion1.SetActive(false);
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

    private void activateTransition (int levelNumber)
    {
        MainCamera.SetActive(false);
        switch(levelNumber)
        {
            case 0:
                transion1.SetActive(true);
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