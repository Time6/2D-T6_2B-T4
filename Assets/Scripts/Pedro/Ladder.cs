using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public float speedLadder;

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Player" && Input.GetKey(KeyCode.UpArrow))
        {
            coll.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speedLadder);
        }
        else if(coll.tag == "Player" && Input.GetKey(KeyCode.DownArrow)) 
        {
            coll.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speedLadder);
        }
        
    }
}
