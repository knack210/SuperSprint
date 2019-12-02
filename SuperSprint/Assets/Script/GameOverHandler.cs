using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    public void RetryLevel()
	{
		if (PlayerPrefs.HasKey("CurrentKey"))
		{
			SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
		}

		else
		{
			SceneManager.LoadScene("Level1");
		}
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
