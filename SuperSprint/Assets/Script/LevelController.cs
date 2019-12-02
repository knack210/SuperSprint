using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private AudioSource source;
	private Scene currentScene;
	[SerializeField] private AudioClip VictoryMusic;

    private void Start()
    {
        source = this.GetComponent<AudioSource>();
        source.volume = source.volume * PlayerPrefs.GetInt("isMusic");
        source.Play();
		currentScene = SceneManager.GetActiveScene();

		PlayerPrefs.SetString("CurrentLevel", currentScene.name);
    }

	public void PlayVictoryMusic()
	{
		if (VictoryMusic != null)
		{
			source?.Stop();
			source?.PlayOneShot(VictoryMusic);
		}
	}
}
