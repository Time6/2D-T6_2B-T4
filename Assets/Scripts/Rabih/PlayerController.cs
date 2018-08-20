using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movimentação
    private float axisX;
    private float axisY;
    public float speed;
    public float jumpForce;
    public float groundChecksize;
    public Transform groundCheck;
    public bool onGround;
    public LayerMask platformMask;

    //nas escadas
   public float gettingUpSpeed;



    private Rigidbody2D rb;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        
        axisX = Input.GetAxis("Horizontal");
        axisY = (Input.GetAxis("Vertical"));
            if (Input.GetAxis("Jump") > 0)
        {
            Jump();
        }
    }


    void FixedUpdate()

    {
        GroundCheck();
        Movimentacao();

    }


    void Movimentacao()
    {

        if (axisX != 0 && onGround)
        {

            rb.velocity = new Vector2(speed * axisX, rb.velocity.y);
        }

    }

    void Jump()
    {
        if (onGround)
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
        }

    }

    void GroundCheck()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundChecksize, platformMask);
    }

    void OnDrawGizmos() {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, groundChecksize);


    }


}





