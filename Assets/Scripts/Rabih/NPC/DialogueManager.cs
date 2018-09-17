using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text nameTxt;
    public Text dialogueTxt;
    public GameObject dialogueBox;

    public Queue<string> sentences;

 private PlayerController player;

	// Use this for initialization
	void Start () {

        sentences = new Queue<string>();
         player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true);
player.talking = true;
        nameTxt.text = dialogue.name;

        sentences.Clear();
        foreach (string sentence in dialogue.sentences)

            {
            sentences.Enqueue(sentence);
             }
        NextSentence();

	}
    public void NextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(LetterByLeter(sentence));
    }

    IEnumerator LetterByLeter(string sentence)
    {
        dialogueTxt.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueTxt.text += letter;
            yield return null;
        }

    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
        player.talking = false;
    }
}
