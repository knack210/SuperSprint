using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Camera.main.SendMessage("CheckForData");
        }
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadMissionMenu()
    {
        SceneManager.LoadScene("Mission Menu");
    }


    public void QuitButton()
    {
        Application.Quit();
    }

  

    public void HighScores()
    {
        SceneManager.LoadScene("HighScoreMenu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }   

}
