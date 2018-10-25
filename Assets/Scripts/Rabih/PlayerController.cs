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

    public float climbingCheckRadius;
    private bool isClimbing;
    private float axisY;
    public LayerMask ladderMask;
    public Transform ladderCheckStart;
    public Transform ladderCheckEnd;

    public GameObject[] roomsPassedTrough;
    public Rigidbody2D rb;
    public int actualRoom;



    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        talking = false;
        actualRoom = 0;


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
        LadderCheck();
        Climbing();
        if (talking)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }


    void Movimentacao()
    {
        if (!Application.isMobilePlatform)
            if (axisX != 0 && onGround && !talking)
            {

                rb.velocity = new Vector2(speed * axisX, rb.velocity.y);
            }
    }

    void Jump()
    {
        if (onGround && !talking)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

    }

    void GroundCheck()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundChecksize, platformMask);
    }

    void LadderCheck()
    {
        Debug.DrawLine(ladderCheckStart.position, ladderCheckEnd.position, Color.red);
        if (Physics2D.Linecast(ladderCheckStart.position, ladderCheckEnd.position, ladderMask))
        {

            axisY = Input.GetAxis("Vertical");
        }

    }


    void Climbing()
    {

        rb.velocity = new Vector2(rb.velocity.x, gettingUpSpeed * axisY);
        isClimbing = Physics2D.OverlapCircle(transform.position, climbingCheckRadius, ladderMask);


    }

    #region Mobile
    public void MoveRight()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
    }

    public void StopMoveRight()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
    public void StopMoveLeft()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);

    }
    #endregion Mobile

    void OnDrawGizmos() {

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, groundChecksize);
        Gizmos.DrawSphere(transform.position, climbingCheckRadius);



    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Room")
        {
             if(Singleton.GetInstance.pathManager.koalaPunkStarted)

                {
                    roomsPassedTrough[actualRoom] = coll.gameObject;
                       actualRoom++;       
                 }

        }
    }


}





