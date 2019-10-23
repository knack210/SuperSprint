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
	[SerializeField]
	private float popupLength;
	     
    private int currentScore;


    private void Start()
    {
        currentScore = 0;
		UpdateScoreCount();
		scorePopup.text = "";        
    }

    public void AddScore(int points)
    {
		TextMeshProUGUI popup = Instantiate(scorePopup, scorePopup.transform);
		popup.text = "+" + points.ToString();

		Destroy(popup, popupLength);
        currentScore += points;
        UpdateScoreCount();
    }
       
    
    private void UpdateScoreCount()
    {
		if (scoreText != null)
		{
			scoreText.text = "Current score: " + currentScore.ToString();
		}
    }

	private void PopUpScore()
	{

	}
}
