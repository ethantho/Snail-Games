using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMirroring : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x < 0)
        {
            spr.flipX = true;
        }

        if(rb.velocity.x > 0)
        {
            spr.flipX = false;
        }

        if (Input.GetButton("Hide"))
        {
            spr.flipX = false;
        }
    }
}
