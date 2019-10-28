using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStationary : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private int scoreAward;
    // private Rigidbody2D rb;
    private bool playerHit;
	private Animator anim;
	private AudioSource source;
	[SerializeField]
	private AudioClip hurtSound;
    // private float thrust = 10.0f;
		
    private void Start()
    {
		source = GetComponent<AudioSource>();
		source.volume = PlayerPrefs.GetInt("IsSound");
		anim = GetComponent<Animator>();
        // rb = GetComponent<Rigidbody2D>();
    }
	
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !playerHit)
        {
            playerHit = true;
            other.SendMessage("TakeDamage", damage);
			anim.SetTrigger("HitPlayer");
			source.PlayOneShot(hurtSound);			
			/*
            //Destroy(gameObject);
            rb.bodyType = RigidbodyType2D.Dynamic;
			*/
        }
    }

    private void OnBecameInvisible()
    {
        if (!playerHit)
        {
            Camera.main.SendMessage("AddScore", scoreAward);
        }

		if (gameObject != null)
		{
			Destroy(gameObject);
		}
    }
}
