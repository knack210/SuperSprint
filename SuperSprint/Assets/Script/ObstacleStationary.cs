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
    private Camera _camera;
    // private float thrust = 10.0f;
		
    private void Start()
    {
        _camera = Camera.main;
		source = GetComponent<AudioSource>();
		source.volume = source.volume * PlayerPrefs.GetInt("isSound");
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
        if (!playerHit && _camera != null)
        {           
            _camera.SendMessage("AddScore", scoreAward);
        }

		if (gameObject != null)
		{
			Destroy(gameObject);
		}
    }

	public void HitByShockwave()
	{
		Debug.Log("Obstacle hit!");
		playerHit = true;
		Destroy(this.gameObject);
	}
}
