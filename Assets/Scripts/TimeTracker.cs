using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeTracker : MonoBehaviour
{
    [SerializeField] float timeLimit;
    float timeRemaining;
    TMP_Text tmp;
    public bool levelOver;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit;
        levelOver = false;
        tmp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 0)
        {
            levelOver = true;
            SceneManager.LoadScene(1);
        }

        tmp.text = timeRemaining.ToString();
        
    }
}