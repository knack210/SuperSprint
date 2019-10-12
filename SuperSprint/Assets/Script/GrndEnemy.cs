using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrndEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementSpeed = -5f;
    [SerializeField]
    private int damage;
    BoxCollider2D myCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
    }

    private void SetSpeed(float speed)
    {
        movementSpeed = (speed * -1f);
    }

    private void SetDamage(int setDamage)
    {
        damage = setDamage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Destroy(this.gameObject);
            other.SendMessage("TakeDamage", damage);
        }
    }
}
