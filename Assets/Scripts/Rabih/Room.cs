using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            CameraController.instance.SetPosition(new Vector2(transform.position.x, transform.position.y));
        }

    }
}