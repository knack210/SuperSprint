using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior: MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int scoreAward;
    private bool active;
    private bool hitPlayer;
    BoxCollider2D myCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        movementSpeed = movementSpeed * -1;
    }

    private void Update()
    {
        if (active)
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hitPlayer = true;
            other.SendMessage("TakeDamage", damage);            
        }
    }

    private void OnBecameVisible()
    {
        active = true;
    }

    private void OnBecameInvisible()
    {
        if (!hitPlayer)
        {
            Camera.main.SendMessage("AddScore", scoreAward);
        }
        Destroy(gameObject);
    }

}
