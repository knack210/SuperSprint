using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private AudioSource source;   

    private void Start()
    {
        source = this.GetComponent<AudioSource>();
        source.volume = source.volume * PlayerPrefs.GetInt("isMusic");
        source.Play();
    }
}
