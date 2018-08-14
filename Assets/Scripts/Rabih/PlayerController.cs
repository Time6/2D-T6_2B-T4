using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float axis;
    public float speed;
    public float jumpForce;
    public float groundChecksize;

    private Rigidbody2D rb;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
        axis = Input.GetAxis("Horizontal");
    }


    void FixedUpdate()

    {

        if (axis != 0)
        {

            rb.velocity = new Vector2(speed * axis, rb.velocity.y);
        }
    }

}

