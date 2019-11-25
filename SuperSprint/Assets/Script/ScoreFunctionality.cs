using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreFunctionality : MonoBehaviour
{
    // Attatch this script to the main camera for the level
	
    [SerializeField]
    private Text scoreText;
	[SerializeField]
	private TextMeshProUGUI scorePopup;
    

    //additional texts for levelcomplete and levelcomplete high score menus
    [SerializeField]
    private Text scoreTextInsideLevelCompleteMenu;

    [SerializeField]
    private Text scoreTextInsideLevelHighScoresMenu;
	     
	[SerializeField] private Transform scoreTransform;
    private int currentScore;


    private void Start()
    {
        currentScore = 0;
		UpdateScoreCount();
        if (scorePopup != null)
        {
            scorePopup.text = "";
        }
    }

    public void AddScore(int points)
    {
        if (points > 0)
        {			
            TextMeshProUGUI popup = Instantiate(scorePopup, scoreTransform);
            popup.text = "+" + points.ToString();
            popup.GetComponent<Animator>().SetTrigger("Move");            

            currentScore += points;
            UpdateScoreCount();

            //updates inside level end menus
            UpdateScoreCountInLevelCompleteMenu();
            UpdateScoreCountInLevelHighScoresMenu();
        }
    }
       
    
    private void UpdateScoreCount()
    {
		if (scoreText != null)
		{
			scoreText.text = "Current score: " + currentScore.ToString();
		}
    }



    //updates score in both level completemenus
    private void UpdateScoreCountInLevelCompleteMenu()
    {
        if (scoreTextInsideLevelCompleteMenu != null)
        {
            scoreTextInsideLevelCompleteMenu.text =  currentScore.ToString();
        }
    }

    private void UpdateScoreCountInLevelHighScoresMenu()
    {
        if (scoreTextInsideLevelHighScoresMenu != null)
        {
            scoreTextInsideLevelHighScoresMenu.text = currentScore.ToString();
        }
    }


    private void PopUpScore()
	{

	}
}
