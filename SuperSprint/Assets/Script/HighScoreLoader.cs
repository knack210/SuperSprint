using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreLoader : MonoBehaviour
{
	[SerializeField] Text[] scoreValue;
	[SerializeField] GameObject[] playerScore;

	private int playerHighscore = -1;

	public void SetPlayerHighscore(int value)
	{
		playerHighscore = value;
	}

	public void SetHighScoreTable(int[] highscores)
	{
		int arrayCount;

		Debug.Log(playerHighscore);

		for (arrayCount = 0; arrayCount < highscores.Length; arrayCount++)
		{
			scoreValue[arrayCount].text = highscores[arrayCount].ToString();

			if (playerHighscore == arrayCount)
			{
				playerScore[arrayCount].SetActive(true);
			}
		}
	}
}
