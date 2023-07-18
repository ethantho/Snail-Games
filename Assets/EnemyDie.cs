using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player: " + collision.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            Debug.Log("Enemy: " + rb.velocity.y);

            //if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y - rb.velocity.y < -0.1f)
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y  < -0.2f)
            {
                
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
