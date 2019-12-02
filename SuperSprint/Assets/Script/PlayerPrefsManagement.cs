using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManagement : MonoBehaviour
{
	/*
     * The default player prefs does not store boolean,
     * to get around this we will use ints in the place of bools,
     * where an int = 0 is "false" and an int = 1 is "true"
     */

	[SerializeField] private GameObject musicButton;
	[SerializeField] private GameObject soundButton;

    // Checks if PlayerPref settings exist
    public void CheckForData()
    {
        if (!PlayerPrefs.HasKey("isSet"))
        {
            SetDefaultData();
        }

        else
        {
            Debug.Log("Prefs have been set");
        }
    }

    public void SetDefaultData()
    {
        PlayerPrefs.SetInt("isSet", 1); // Bool for determing if save data has been created
        PlayerPrefs.SetInt("isLevel2", 0); // Bool for determing if Level 2 is unlocked
        PlayerPrefs.SetInt("isLevel3", 0); // Bool for determing if Level 3 is unlocked
        PlayerPrefs.SetInt("isMusic", 1); // Bool for determing if Background music is enabled
        PlayerPrefs.SetInt("isSound", 1); // Bool for determing if Sound Effects are enabled

        PlayerPrefs.SetInt("firstL1", 150); // Int determing default first place score for Level 1
        PlayerPrefs.SetInt("secondL1", 100); // Int determing default second place score for Level 1
        PlayerPrefs.SetInt("thirdL1", 50); // Int determing default third place score for Level 1


        PlayerPrefs.SetInt("firstL2", 150); // Int determing first place score for Level 2
        PlayerPrefs.SetInt("secondL2", 100); // Int determing second place score for Level 2
        PlayerPrefs.SetInt("thirdL2", 50); // Int determing third place score for Level 2
        
        PlayerPrefs.SetInt("firstL3", 275); // Int determing first place score for Level 3
        PlayerPrefs.SetInt("secondL3", 200); // Int determing second place score for Level 3
        PlayerPrefs.SetInt("thirdL3", 175); // Int determing third place score for Level 3

       // PlayerPrefs.SetString("name", "BILL"); // String containing player entered name

    }

	public void DeleteAllData()
	{
		PlayerPrefs.DeleteAll();
		SetDefaultData();
		if (musicButton != null ) musicButton.SendMessage("SetText", true);
		if (soundButton != null) soundButton.SendMessage("SetText", true);
	}
}
