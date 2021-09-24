using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
	public TMP_Text dialogueText;
	public Dialogue dialogue;
	public Animator animator;

	public float velocity = 1.0f;

	private Queue<string> sentences;

	// Use this for initialization
	void Awake()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue()
	{
		Debug.Log("Set IsOpen --> True");
		animator.SetBool("IsOpen", true);
		Debug.Log("IsOpen --> " + animator.GetBool("IsOpen"));


		sentences.Clear();

		Debug.Log("sentences length: " + dialogue.sentences.Length);
		foreach (string sentence in dialogue.sentences)
		{
			Debug.Log("sentence: " + sentence.ToCharArray());
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(velocity * Time.deltaTime);
		}
	}

	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
	}

}