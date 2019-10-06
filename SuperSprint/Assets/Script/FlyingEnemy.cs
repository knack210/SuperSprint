using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementSpeed = -5f, frequency = 15f, magnitude = 0.2f;
    private int damage = 100;
    CapsuleCollider2D myCollider;
    private CharHealth characterHealth;
    Vector3 position;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
        myCollider.isTrigger = true;
        characterHealth = FindObjectOfType<CharHealth>();
        position = transform.position;
    }

    private void Update()
    {
        position += transform.right * Time.deltaTime * movementSpeed;
        transform.position = position + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void SetSpeed(float speed)
    {
        movementSpeed = (speed * -1f);
    }

    private void SetDamage(int setDamage)
    {
        damage = setDamage;
    }

    private void SetMagnitude(float mag)
    {
        magnitude = mag;
    }

    private void SetFrequency(float freq)
    {
        frequency = freq;
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