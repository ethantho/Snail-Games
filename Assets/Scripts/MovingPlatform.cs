using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 1;
    public float distance = 10;
    private Vector2 startPos;

    public bool circling;
    private float toggle = 0;

    public float offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        if(circling)
            toggle = 1;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + new Vector2(toggle * distance * Mathf.Cos(speed * Time.time + offset), distance * Mathf.Sin(speed * Time.time + offset));
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && circling)
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && circling)
        {
            collision.collider.transform.SetParent(null);
        }
    }


}
