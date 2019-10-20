using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreFunctionality : MonoBehaviour
{
    // Attatch this script to the main camera for the level


    [SerializeField]
    private Text scoreText;


  
    private int currentScore;


    private void Start()
    {
        currentScore = 0;
        UpdateText();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateText();
    }
       
    
    private void UpdateText()
    {
        scoreText.text = "Current score: " + currentScore.ToString();
    }
}
