using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicButtonClicked : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI musicText;

    private void Start()
    {
        SetText(IsOn(PlayerPrefs.GetInt("isMusic")));
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

    private void SetText(bool state)
    {
        if (state)
        {
            musicText.text = "Music : ON";
        }

        else
        {
            musicText.text = "Music : OFF";
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
