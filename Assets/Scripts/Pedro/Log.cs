using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3f;


    void OnEnable()
    {
        speed = 3f;
        transform.position = new Vector2(-9.66f, -2.4f);
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Room")
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
        }
    }
}