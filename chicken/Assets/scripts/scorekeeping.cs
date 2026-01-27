using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class scorekeeping : MonoBehaviour

{

    TextMeshProUGUI score;
    GameObject spawner;
    
  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
        if (SceneManager.GetActiveScene().buildIndex >= 1)
        {
            score = GameObject.FindGameObjectWithTag("UI_Score").GetComponent<TextMeshProUGUI>();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score:0" + spawner.GetComponent<spawner>().waveNumber;
     
    }
}
