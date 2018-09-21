using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            CameraController.instance.SetPosition(new Vector2 (transform.position.x, transform.position.y));
        }

    }





}