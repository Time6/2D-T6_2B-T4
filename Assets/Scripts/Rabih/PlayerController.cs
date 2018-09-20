using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movimentação
    private float axisX;
    
    public float speed;
    public float jumpForce;
    public float groundChecksize;
    public Transform groundCheck;
    public bool onGround;
    public LayerMask platformMask;
    public bool talking;

    //nas escadas
   public float gettingUpSpeed;



    public Rigidbody2D rb;


    public BoxCollider2D[] pathRooms;
    private int actualRoom;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        talking = false;


    }

    // Update is called once per frame
    void Update()
    {
        
        axisX = Input.GetAxis("Horizontal");
        
            if (Input.GetAxis("Jump") > 0)
        {
            Jump();
        }
    }


    void FixedUpdate()

    {
        GroundCheck();
        Movimentacao();
        if(talking)
        {
            rb.velocity = new Vector2(0,rb.velocity.y);
        }

    }


    void Movimentacao()
    {

        if (axisX != 0 && onGround && !talking)
        {

            rb.velocity = new Vector2(speed * axisX, rb.velocity.y);
        }

    }

    void Jump()
    {
        if (onGround && !talking)
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

    void OnTriggerEnter2D(BoxCollider2D coll)
    {
        if(coll.tag == "Room"){
        if(koalaPunkStarted)
        {
            
         if(coll != pathRooms[actualRoom])
         {
             pathRooms[actualRoom] = coll;
             actualRoom++;
         }

        }
        }
    }


}





