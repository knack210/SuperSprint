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

	//[SerializeField]
	//private Text scoreTextInsideLevelHighScoresMenu;

	//[SerializeField] private GameObject HighScoreMenu;	

	[SerializeField] private Transform scoreTransform;
    private int currentScore;

	private int playerScorePosition;
	private int[] highscores;

    private void Start()
    {
        currentScore = 0;
		UpdateScoreCount();
        if (scorePopup != null)
        {
            scorePopup.text = "";
        }
    }

	public void UpdateLevelScores()
	{
		this.SendMessage("PlayVictoryMusic");
		UpdateScoreCountInLevelCompleteMenu();
		UpdateScoreCountInLevelHighScoresMenu();
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
        }
    }
    
	public void DebugValue()
	{
		currentScore = 160;
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
		Debug.Log("Here");
		ScoreToArray();
		SortArray();
		ArrayToScore();
		
		this.SendMessage("SetPlayerHighscore", playerScorePosition);
		this.SendMessage("SetHighScoreTable", highscores);
        
    }

	private void ScoreToArray()
	{
		highscores = new int[3];

		switch (PlayerPrefs.GetString("CurrentLevel"))
		{
			case "Level1":
			{
					highscores[0] = PlayerPrefs.GetInt("firstL1");
					highscores[1] = PlayerPrefs.GetInt("secondL1");
					highscores[2] = PlayerPrefs.GetInt("thirdL1");
			} break;

			case "Level2":
			{
					highscores[0] = PlayerPrefs.GetInt("firstL2");
					highscores[1] = PlayerPrefs.GetInt("secondL2");
					highscores[2] = PlayerPrefs.GetInt("thirdL2");
			} break;

			case "Level3":
			{
					highscores[0] = PlayerPrefs.GetInt("firstL3");
					highscores[1] = PlayerPrefs.GetInt("secondL3");
					highscores[2] = PlayerPrefs.GetInt("thirdL3");
			} break;

			default:
			{
					Debug.Log("Couldn't reference player name prefab");
			} break;
		
		}
	}

	private void SortArray()
	{
		int arrayCount;
		int temporaryPosition;
		int valueToReplace = 0;

		playerScorePosition = -1;

		for (arrayCount = 0; arrayCount < 3; arrayCount++)
		{
			if (currentScore > highscores[arrayCount])
			{
				valueToReplace = highscores[arrayCount];
				highscores[arrayCount] = currentScore;
				playerScorePosition = arrayCount;

				break;
			}
		}

		for (arrayCount++; arrayCount < 3; arrayCount++)
		{
			if (valueToReplace > highscores[arrayCount])
			{
				temporaryPosition = highscores[arrayCount];
				highscores[arrayCount] = valueToReplace;
				valueToReplace = temporaryPosition;
			}
		}
	}

	private void ArrayToScore()
	{
		switch (PlayerPrefs.GetString("CurrentLevel"))
		{
			case "Level1":
			{
				PlayerPrefs.SetInt("firstL1", highscores[0]);
				PlayerPrefs.SetInt("secondL1", highscores[1]);
				PlayerPrefs.SetInt("thirdL1", highscores[2]);
			}
			break;

			case "Level2":
			{
				PlayerPrefs.SetInt("firstL2", highscores[0]);
				PlayerPrefs.SetInt("secondL2", highscores[1]);
				PlayerPrefs.SetInt("thirdL2", highscores[2]);
			}
			break;

			case "Level3":
			{
				PlayerPrefs.SetInt("firstL3", highscores[0]);
				PlayerPrefs.SetInt("secondL3", highscores[1]);
				PlayerPrefs.SetInt("thirdL3", highscores[2]);
			}
			break;

			default:
			{
				Debug.Log("Couldn't reference player name prefab");
			}
			break;

		}
	}
}
