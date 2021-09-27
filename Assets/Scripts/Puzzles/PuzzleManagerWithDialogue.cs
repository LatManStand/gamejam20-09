using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManagerWithDialogue : MonoBehaviour
{
    public GameObject dialogue;

    private bool showDialogue;

    private void Start()
    {
        showDialogue = true;
        dialogue.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (showDialogue)
        {
            showDialogue = false;
            Dialogue();
            Debug.Log("Hey");
        }
    }

    public void UI_GoBackToMap()
    {
        GameManager.instance.SaveData();
        GameManager.instance.LoadScene("Map");
    }

    void Dialogue()
    {
        dialogue.SetActive(true);
        dialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
