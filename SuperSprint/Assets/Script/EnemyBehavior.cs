using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior: MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed = -5f;
    [SerializeField]
    private int damage;
    private bool active;
    CapsuleCollider2D myCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
        myCollider.isTrigger = true;
    }

    private void Update()
    {
        if (active)
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
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
            other.SendMessage("TakeDamage", damage);
            Destroy(gameObject);
        }
    }

    private void OnBecameVisible()
    {
        active = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
