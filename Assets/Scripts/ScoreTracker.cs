using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    int score;
    TMP_Text tmp;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        tmp = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = score.ToString();
    }

    public void GetPoints(int points)
    {
        score += points * 1000;
        DataTracker.finalScore = score;
        GetComponent<AudioSource>().Play();
    }
}
