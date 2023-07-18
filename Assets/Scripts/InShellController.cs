using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//THIS SCRIPT CONTROLS BEHAVIOR WHEN THE SNAIL IS HIDDEN IN HIS SHELL
//
public class InShellController : MonoBehaviour
{
    [SerializeField] float jumpPower;
    Rigidbody2D rb;
    float distToGround;
    float width;
    public CapsuleCollider2D col;
    public bool grounded;
    float normalGravityScale;
    public Transform center;
    public float rollspeed = 1f;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        normalGravityScale = rb.gravityScale;
        //col = GetComponent<CapsuleCollider2D>();
        distToGround = col.bounds.extents.y;
        Debug.Log(distToGround);
        width = col.bounds.extents.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();

        if (grounded)
        {
            //rb.gravityScale = 10 * normalGravityScale;
            //rb.gravityScale = 0.1f;
        }
        else
        {
            //rb.gravityScale = normalGravityScale;
            //rb.gravityScale = 10;
        }

        if (grounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        Roll();

    }

    void CheckIfGrounded()
    {
        float leeway = 0.2f;

        

        //down
        RaycastHit2D hitMid = Physics2D.Raycast(center.position, -Vector2.up, distToGround + leeway, LayerMask.GetMask("Ground"));
        RaycastHit2D hitCirc = Physics2D.CircleCast(center.position, 0.5f, Vector2.down, distToGround + leeway, LayerMask.GetMask("Ground"));

        /*RaycastHit2D hitLeft = Physics2D.Raycast(rb.position + (width * -Vector2.right), -Vector2.up, distToGround + leeway, LayerMask.GetMask("Ground"));
        RaycastHit2D hitRight = Physics2D.Raycast(rb.position + (width * Vector2.right), -Vector2.up, distToGround + leeway, LayerMask.GetMask("Ground"));*/


        Debug.DrawRay(center.position, -Vector2.up * (distToGround + leeway) ,Color.red , 1f, false);
        

        if (hitCirc)
        {
            grounded = true;
            return;
        }




        //Debug.Log(hit.collider.tag);



        grounded = false;
        

    }


    void Jump()
    {
        grounded = false;
        rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
    }

    void Roll()
    {
        float speed = Input.GetAxis("Horizontal");

        if (grounded)
        {
            rb.velocity += new Vector2(speed * rollspeed, 0);
        }
    }
}
