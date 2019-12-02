using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButtonController : MonoBehaviour
{
	private Button buttonRef;
	//[Serialize Field] private GameObject particleEmitter;

    private void Start()
	{
		buttonRef = this.GetComponent<Button>();
	}

	public void Enable()
	{
		if (!buttonRef.IsInteractable())
		{
			buttonRef.interactable = true;
			// turn on particle here
		}
	}

	public void Disable ()
	{
		if (buttonRef.IsInteractable())
		{
			buttonRef.interactable = false;
			// turn off particle here

		}
	}
}
