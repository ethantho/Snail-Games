using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    TMP_Text txt;
    // Start is called before the first frame update


    void Start()
    {
        txt = GetComponent<TMP_Text>();
        txt.text = DataTracker.finalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
