using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    public Dialogue dialogue;
    public GameObject dialogueBox;
    
    public GameObject pressButton;

  private PlayerController player;


  public void Start()
  {

  player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

  }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


    void OnTriggerStay2D(Collider2D coll)
    {
        if(!player.talking)
        {
        pressButton.SetActive(true);
        }

        if(player.talking)
        {
        pressButton.SetActive(false);
        }

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
      void OnTriggerExit2D(Collider2D coll)
      {
          if(coll.tag == "Player")
          {
              pressButton.SetActive(false);
          }

      }



}
