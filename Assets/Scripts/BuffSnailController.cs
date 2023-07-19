using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSnailController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float topSpeed;
    [SerializeField] float jumpPower;
    [SerializeField] float friction;

    float dashCoefficient;


    float xSpeed;

    public bool grounded;

    float distToGround;

    CapsuleCollider2D col;

    Vector2 prevPos;

    public bool dashing;
    float dashTimer;
    [SerializeField] float dashCoolDown;
    // Start is called before the first frame update
    void Start()
    {
        dashing = false;
        dashTimer = 0;
        dashCoefficient = 1f;
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
        distToGround = col.bounds.extents.y;
        Debug.Log(distToGround);
        prevPos = rb.position;
    }

    // Update is called once per frame
    void Update()
    {

        CheckIfGrounded();

        if (grounded && Input.GetAxis("Horizontal") == 0)
        {
            //DoFriction();
        }

        if (xSpeed > topSpeed)
        {
            xSpeed = topSpeed;
        }

        if (xSpeed < -topSpeed)
        {
            xSpeed = -topSpeed;
        }

        MoveLeftRight();



        DoJumping();

        DoDashing();

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


        //xSpeed += Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        xSpeed = Mathf.Lerp(xSpeed, Input.GetAxis("Horizontal") * moveSpeed * dashCoefficient, Time.deltaTime * friction * dashCoefficient);
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }

    void DoJumping()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();
        }
    }

    /*void DoFriction()
    {
        if (xSpeed > 0)
        {
            xSpeed = Mathf.Max(0, xSpeed - (friction * Time.deltaTime));
        }
        if (xSpeed < 0)
        {
            xSpeed = Mathf.Min(0, xSpeed + (friction * Time.deltaTime));
        }

    }*/

    void DoDashing()
    {
        //start dash
        if (Input.GetButtonDown("Fire3") && Mathf.Abs(dashTimer) <= 0.1f)
        {
            dashCoefficient = 3f;
            dashing = true;
        }

        //stop dash early
        if (Input.GetButtonUp("Fire3"))
        {
            dashing = false;

        }

        //continue dash

        if(dashing && dashTimer < dashCoolDown)
        {
            dashTimer += Time.deltaTime;
        }

        //stop dash by force
        if(dashing && dashTimer >= dashCoolDown)
        {
            dashing = false;
        }

        if (!dashing)
        {
            dashCoefficient = 1f;
            dashing = false;
            dashTimer = Mathf.Max(0, dashTimer - 0.5f * Time.deltaTime);
        }
        
    }


}