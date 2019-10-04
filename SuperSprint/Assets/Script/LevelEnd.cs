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

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag("Player"))           
        {          
            victoryMessage.text = "Congratulations!";
        }
    }
}
