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
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
        }
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
    }

    public void LoadLevel2()
    {
        if (PlayerPrefs.GetInt("isLevel2") == 1)
        {
            SceneManager.LoadScene("Level2");
        }
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
    }

    public void LoadLevel3()
    {
        if (PlayerPrefs.GetInt("isLevel3") == 1)
        {
            Debug.Log("Add a level 3!");
        }
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
		Music mPlayer = GameObject.FindGameObjectWithTag("Music").GetComponent<Music>();
		mPlayer.PlayMusic();
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

    // Debug, remove for final build
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Unlocked!");
            PlayerPrefs.SetInt("isLevel2", 1);
            PlayerPrefs.SetInt("isLevel3", 1);

        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Locked!");
            PlayerPrefs.SetInt("isLevel2", 0);
            PlayerPrefs.SetInt("isLevel3", 0);

        }
    }*/
}
