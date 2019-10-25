using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SoundButtonClicked : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI soundText;

    private void Start()
    {
        SetText(IsOn(PlayerPrefs.GetInt("isSound")));
    }

    public void Clicked()
    {
        if (IsOn(PlayerPrefs.GetInt("isSound")))
        {
            PlayerPrefs.SetInt("isSound", 0);
            SetText(false);
        }

        else
        {
            PlayerPrefs.SetInt("isSound", 1);
            SetText(true);
        }
    }

    private void SetText(bool state)
    {
        if (state)
        {
            soundText.text = "Sound : ON";
        }

        else
        {
            soundText.text = "Sound : OFF";
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
