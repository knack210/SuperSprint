using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiceScoreDestroy : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = this.GetComponent<AudioSource>();
        source.volume = source.volume * PlayerPrefs.GetInt("isSound");
    }

    private void PlaySound()
    {
        source.Play();
    }

    private void DestroyScore()
    {
        Destroy(this.gameObject);
    }
}
