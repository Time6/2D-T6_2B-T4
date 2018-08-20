using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    public float positionX;
    public float positionZ;


    void OnEnable()
    {
        speed = 5f;
        transform.position = new Vector2(positionX, positionZ);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
            speed += 0.01f;
            rb.velocity = new Vector2(speed, rb.velocity.y);    
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Stop")
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}