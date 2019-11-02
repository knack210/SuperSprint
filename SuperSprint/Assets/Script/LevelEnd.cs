using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private Scene scene;
    public Text victoryMessage;
    // Start is called before the first frame update
    [SerializeField]
    private GameObject levelCompleteMenu;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        victoryMessage.text = "";
        levelCompleteMenu.SetActive(false);
    }

    private void OnBecameVisible()
    {
        Camera.main.SendMessage("DisableText");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {		
        if (other.CompareTag("Player"))           
        {
			other.SendMessage("StopRunning");
            // victoryMessage.text = "Congratulations!";

            if (scene.name == "Level1")
            {
                PlayerPrefs.SetInt("isLevel2", 1);
            }

            if (scene.name == "Level2")
            {
                PlayerPrefs.SetInt("isLevel3", 1);
            }

            levelCompleteMenu.SetActive(true);
        }
    }
}
