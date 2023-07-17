using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float topSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float friction;


    float xSpeed;

    public bool grounded;

    float distToGround;

    BoxCollider2D col;

    Vector2 prevPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        distToGround = col.bounds.extents.y;
        Debug.Log(distToGround);
        prevPos = rb.position;
    }

    // Update is called once per frame
    void Update()
    {

        CheckIfGrounded();

        if (grounded)
        {
            DoFriction();
        }

        if(xSpeed > topSpeed)
        {
            xSpeed = topSpeed;
        }

        if(xSpeed < -topSpeed)
        {
            xSpeed = -topSpeed;
        }

        MoveLeftRight();

        

        DoJumping();



    }

    void FixedUpdate()
    {
        
    }

    void CheckIfGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(rb.position, -Vector2.up, distToGround + 0.1f, LayerMask.GetMask("Ground"));

        //Debug.Log(hit.collider.tag);

        if (hit)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }


        
    }

    void MoveLeftRight()
    {   //buggy
        //rb.MovePosition(rb.position + (Input.GetAxis("Horizontal") * moveSpeed *  Time.deltaTime * Vector2.right));


        xSpeed += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }

    void DoJumping()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
        }
    }

    void DoFriction()
    {
        if(xSpeed > 0)
        {
            xSpeed = Mathf.Max(0, xSpeed - (friction * Time.deltaTime));
        }
        if(xSpeed < 0)
        {
            xSpeed = Mathf.Min(0, xSpeed + (friction * Time.deltaTime));
        }

    }
    

}
