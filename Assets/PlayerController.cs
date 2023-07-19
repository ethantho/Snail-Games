using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool hiding;

    public Animator anim;

    public CapsuleCollider2D buffCol;
    public CircleCollider2D shellCol;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        hiding = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfHiding();

        if(hiding)
        {
            BuffControls();
        }
    }

    void CheckIfHiding()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Hide();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Unhide();
        }
    }

    void Hide()
    {
        hiding = true;
        buffCol.enabled = false;
        shellCol.enabled = true;
    }

    void Unhide()
    {
        hiding = false;
        buffCol.enabled = true;
        shellCol.enabled = false;
    }

    void BuffControls()
    {

    }

    void Run()
    {

    }



}
