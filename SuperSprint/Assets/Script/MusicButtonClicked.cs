using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicButtonClicked : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI musicText;
	private GameObject Music;

    private void Start()
    {
        SetText(IsOn(PlayerPrefs.GetInt("isMusic")));
		Music = GameObject.Find("Music");

    }

    public void Clicked()
    {
        if (IsOn(PlayerPrefs.GetInt("isMusic")))
        {
            PlayerPrefs.SetInt("isMusic", 0);
            SetText(false);
        }

        else
        {
            PlayerPrefs.SetInt("isMusic", 1);
            SetText(true);
        }
    }

    public void SetText(bool state)
    {
        if (state)
        {
            musicText.text = "Music : ON";
			if (Music != null) Music.SendMessage("PlayMusic");			
        }

        else
        {
            musicText.text = "Music : OFF";
			if (Music != null) Music.SendMessage("StopMusic");
		}
    }

    private bool IsOn(int pref)
    {
        if (pref == 1)
        {
            return true;
        }

        return false;
    }
}
