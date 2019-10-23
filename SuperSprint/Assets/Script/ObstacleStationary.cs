using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStationary : MonoBehaviour
{
    [SerializeField]
    private float damage;
    [SerializeField]
    private int scoreAward;
    private Rigidbody2D rb;
    private bool playerHit;
    private float thrust = 10.0f;
    BoxCollider2D myCollider;


    void Start()
    {        
        myCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerHit = true;
            other.SendMessage("TakeDamage", damage);            
            //Destroy(gameObject);
            rb.bodyType = RigidbodyType2D.Dynamic;
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
