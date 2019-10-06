using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrndEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementSpeed = -5f;
    private int damage = 100;
    CapsuleCollider2D myCollider;
    private CharHealth characterHealth;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
        myCollider.isTrigger = true;
        characterHealth = FindObjectOfType<CharHealth>();
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject);
            characterHealth.TakeDamage(damage);
        }
    }
}
