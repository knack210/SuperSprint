using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOYMK2Power : MonoBehaviour
{
	[SerializeField]
	private GameObject shockWave;
	[SerializeField]
	private Transform shockWaveSpawn;

	

	private void Start()
	{
		this.SendMessage("SetDepletionRate", 100);
		
	}

	private void Update()
	{
		if (Input.GetButtonDown("Power"))
		{
			Debug.Log("Power Attempt");
			SendMessage("AttemptPower");
		}
	}

	public void ActivatePower()
	{
		this.SendMessage("DisableRegen");
		GameObject shockWaveInstance = Instantiate(shockWave, shockWaveSpawn.position, Quaternion.identity) as GameObject;
	}

	public void DisablePower()
	{
		this.SendMessage("EnableRegen");
	}	
}
