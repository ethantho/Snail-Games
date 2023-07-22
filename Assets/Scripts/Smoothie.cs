using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoothie : MonoBehaviour
{
    [SerializeField] int points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindAnyObjectByType<ScoreTracker>().GetPoints(points);
            
            Destroy(gameObject);
        }
    }

    
}
