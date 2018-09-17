using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    public Dialogue dialogue;
    public GameObject dialogueBox;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    void OnTriggerStay2D(Collider2D coll)
    {
       
        if (coll.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
           
           if (!dialogueBox.activeSelf)
            {
                  TriggerDialogue();
             }

              if (dialogueBox.activeSelf)
             {
                  FindObjectOfType<DialogueManager>().NextSentence();
             }
             


        }

    }
}
