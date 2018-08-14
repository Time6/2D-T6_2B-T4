using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float axis;
    public float speed;
    public float jumpForce;
    public float groundCheckSize;
    public bool onGround;
    public Transform groundCheck;
    public LayerMask platformMask;

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

        Movimentacao();
        print(onGround);

    }



    public void Movimentacao()
    {

        if (axis != 0)
        {

            rb.velocity = new Vector2(speed * axis, rb.velocity.y);
        }


    }

    void GroundCheck()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckSize , platformMask);
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, groundCheckSize);
    }

}

