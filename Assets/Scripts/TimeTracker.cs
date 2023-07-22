using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeTracker : MonoBehaviour
{
    [SerializeField] float timeLimit;
    public float timeRemaining;
    TMP_Text tmp;
    public bool levelOver;
    AudioSource tick;
    bool tickStarted;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit;
        levelOver = false;
        tmp = GetComponent<TMP_Text>();

        tick = GetComponent<AudioSource>();
        tickStarted = false;
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

        if(timeRemaining < 30f)
        {
            StartCoroutine(Ticking());
        }
        
    }

    IEnumerator Ticking()
    {
        while (timeRemaining > 0)
        {
            tick.Play();
            yield return new WaitForSeconds(1f);
        }
    }
}
