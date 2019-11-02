﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior: MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float damage;
    [SerializeField]
    private int scoreAward;
    private bool active;
    private bool hitPlayer;
    private AudioSource source;
    [SerializeField]
    private AudioClip entryNoise;
    PolygonCollider2D myCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<PolygonCollider2D>();
        source = GetComponent<AudioSource>();
        source.volume = source.volume * PlayerPrefs.GetInt("isSound");
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
        Debug.Log("Approaching");
        PlaySound();
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

    private void AttackOverride()
    {
        active = false;
    }

    public void PlaySound()
    {
        source.PlayOneShot(entryNoise);
    }

}
