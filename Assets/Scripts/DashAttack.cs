using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttack : MonoBehaviour
{
    bool attacking;
    SpriteRenderer spr;
    ShellHideController shc;
    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        spr = GetComponent<SpriteRenderer>();
        shc = GetComponentInParent<ShellHideController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire3") && !shc.hiding)
        {
            attacking = true;
        }
        else
        {
            attacking = false;
        }


        if (attacking)
        {
            spr.enabled = true;
        }
        else
        {
            spr.enabled = false;
        }
    }


}
