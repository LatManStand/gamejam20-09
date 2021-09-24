using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Init dialogue");
        TriggerDialogue();
    }

    public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue();

	}


}