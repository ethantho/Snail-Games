using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//
//THIS SCRIPT CONTROLS WHETHER OR NOT THE SNAIL IS HIDING IN HIS SHELL
//
public class ShellHideController : MonoBehaviour
{
    
    [SerializeField] 
    public Animator anim;
    [SerializeField]
    CapsuleCollider2D capsuleCollider;
    CircleCollider2D shellCollider;
    public bool hiding;
    public Transform Center;

    private Rigidbody2D rb;


    BuffSnailController nonHidingController;
    InShellController hidingController;
    // Start is called before the first frame update
    void Start()
    {
        nonHidingController = GetComponent<BuffSnailController>();
        hidingController = GetComponent<InShellController>();
        nonHidingController.enabled = true;
        hidingController.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        shellCollider = GetComponent<CircleCollider2D>();
        shellCollider.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Hide"))
        {
            Hide();

        }

        if (Input.GetButtonUp("Hide"))
        {
            UnHide();
        }


    }

    void Hide()
    {
        if (capsuleCollider != null)
            capsuleCollider.enabled = false;
        shellCollider.enabled = true;

        nonHidingController.enabled = false;
        hidingController.enabled = true;
        rb.freezeRotation = false;
        if(anim != null)
            anim.SetBool("hiding", true);
        hiding = true;


    }

    void UnHide()
    {
        transform.rotation = Quaternion.identity;
        if (capsuleCollider != null)
            capsuleCollider.enabled = true;
        shellCollider.enabled = false;
        nonHidingController.enabled = true;
        hidingController.enabled = false;
        
        rb.freezeRotation = true;
        if (anim != null)
            anim.SetBool("hiding", false);
        hiding = false;

        //transform.position = Center.position - Vector3.right;
    }


}
