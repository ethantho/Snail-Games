using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ReturnHome : MonoBehaviour
{
    TextMeshProUGUI txt;
    bool readyToLeave;
    TimeTracker tt;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponentInChildren<TextMeshProUGUI>();
        tt = FindAnyObjectByType<TimeTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && readyToLeave)
        {
            DataTracker.finalScore += (int) tt.timeRemaining;
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            txt.enabled = true;
            readyToLeave = true;
        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            txt.enabled = false;
            readyToLeave = false;
        }
    }
}
