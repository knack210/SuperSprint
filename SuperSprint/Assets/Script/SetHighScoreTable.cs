using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetHighScoreTable : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI score1L1;
	[SerializeField] private TextMeshProUGUI score2L1;
	[SerializeField] private TextMeshProUGUI score3L1;
	[SerializeField] private TextMeshProUGUI score1L2;
	[SerializeField] private TextMeshProUGUI score2L2;
	[SerializeField] private TextMeshProUGUI score3L2;
	[SerializeField] private TextMeshProUGUI score1L3;
	[SerializeField] private TextMeshProUGUI score2L3;
	[SerializeField] private TextMeshProUGUI score3L3;

	private void Start()
	{
		score1L1.text = PlayerPrefs.GetInt("firstL1").ToString();
		score2L1.text = PlayerPrefs.GetInt("secondL1").ToString();
		score3L1.text = PlayerPrefs.GetInt("thirdL1").ToString();

		score1L2.text = PlayerPrefs.GetInt("firstL2").ToString();
		score2L2.text = PlayerPrefs.GetInt("secondL2").ToString();
		score3L2.text = PlayerPrefs.GetInt("thirdL2").ToString();

		score1L3.text = PlayerPrefs.GetInt("firstL3").ToString();
		score2L3.text = PlayerPrefs.GetInt("secondL3").ToString();
		score3L3.text = PlayerPrefs.GetInt("thirdL3").ToString();
	}
}
