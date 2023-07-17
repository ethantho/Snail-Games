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

    private Rigidbody2D rb;

    TarodevController.PlayerController nonHidingController;
    InShellController hidingController;
    // Start is called before the first frame update
    void Start()
    {
        nonHidingController = GetComponent<TarodevController.PlayerController>();
        hidingController = GetComponent<InShellController>();
        nonHidingController.enabled = true;
        hidingController.enabled = false;
        rb = GetComponent<Rigidbody2D>();

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
        nonHidingController.enabled = false;
        hidingController.enabled = true;
        rb.freezeRotation = false;
        if(anim != null)
            anim.SetBool("hiding", true);
    }

    void UnHide()
    {
        nonHidingController.enabled = true;
        hidingController.enabled = false;
        transform.rotation = Quaternion.identity;
        rb.freezeRotation = true;
        if (anim != null)
            anim.SetBool("hiding", false);
    }


}
