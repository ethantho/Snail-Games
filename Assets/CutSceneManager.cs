using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CutSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    int currentImage;
    [SerializeField] Sprite[] scenes;
    [SerializeField] TMP_Text[] dialogue;

    void Start()
    {
        currentImage = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            dialogue[currentImage].gameObject.SetActive(false);
            currentImage++;
            if (currentImage >= scenes.Length)
            {
                DataTracker.returnedHome = false;
                SceneManager.LoadScene(2);
                return;
            }

            GetComponent<Image>().sprite = scenes[currentImage];
            GetComponent<Image>().color = Color.white;

            dialogue[currentImage].gameObject.SetActive(true);
        }     

        

        
    }
}
