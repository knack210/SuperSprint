using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    public Text victoryMessage;
    // Start is called before the first frame update
    void Start()
    {
        victoryMessage.text = "";
    }

    private void OnBecameVisible()
    {
        Camera.main.SendMessage("DisableText");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log("I've been entered");
        if (other.CompareTag("Player"))           
        {
			other.SendMessage("StopRunning");
            victoryMessage.text = "Congratulations!";
        }
    }
}
