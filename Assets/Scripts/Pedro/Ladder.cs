 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public float speedLadder;
    public PlayerController player;


    void Start()
{
    player = GameObject.Find("Player").GetComponent<PlayerController>();
} 

 
    void OnTriggerStay2D(Collider2D coll)
    {
      

        if (coll.tag == "Player" && Input.GetKey(KeyCode.UpArrow))
        {
           player.rb.velocity = new Vector2 (0 , speedLadder);
            player.rb.gravityScale = 0;
            Physics2D.IgnoreLayerCollision(8, 10, true);
        }
        else if(coll.tag == "Player" && Input.GetKey(KeyCode.DownArrow)) 
        {
             player.rb.velocity = new Vector2 (0 , -speedLadder);
              player.rb.gravityScale = 0;
            Physics2D.IgnoreLayerCollision(8, 10, true);
        }
        else if (coll.tag == "Player")
        {
             player.rb.velocity = new Vector2 (0,0);
              player.rb.gravityScale = 0;
            Physics2D.IgnoreLayerCollision(8, 10, true);
        }
        
    }
 void OnTriggerExit2D(Collider2D other) {
     
     if (other.tag == "Player")
     {
          player.rb.gravityScale = 1;
            Physics2D.IgnoreLayerCollision(8, 10, false);
        }
        
    }
  
}
