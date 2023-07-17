using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//
//THIS SCRIPT CONTROLS WHETHER OR NOT THE SNAIL IS HIDING IN HIS SHELL
//
public class ShellHideController : MonoBehaviour
{
    TarodevController.PlayerController nonHidingController;
    InShellController hidingController;
    // Start is called before the first frame update
    void Start()
    {
        nonHidingController = GetComponent<TarodevController.PlayerController>();
        hidingController = GetComponent<InShellController>();
        nonHidingController.enabled = true;
        hidingController.enabled = false;

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
    }

    void UnHide()
    {
        nonHidingController.enabled = true;
        hidingController.enabled = false;
    }


}
