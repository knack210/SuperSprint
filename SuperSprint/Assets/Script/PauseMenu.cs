using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    private static bool GameIsPaused;
    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private GameObject pauseMenuButton;
    [SerializeField]
    private GameObject ResumeGameButton;
    [SerializeField]
    private GameObject powerButton;


    private void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


    }


   public void Resume()
    {
        ResumeGameButton.SetActive(false);
        pauseMenuButton.SetActive(true);
        powerButton.SetActive(true);

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

   public void Pause()
    {
        pauseMenuButton.SetActive(false);
        powerButton.SetActive(false);
        ResumeGameButton.SetActive(true);


        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
