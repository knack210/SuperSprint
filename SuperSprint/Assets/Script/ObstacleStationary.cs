using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStationary : MonoBehaviour
{
    [SerializeField]
    private int damage;
    private Rigidbody2D rb;
    private float thrust = 10.0f;
    BoxCollider2D myCollider;


    void Start()
    {        
        myCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessage("TakeDamage", damage);            
            //Destroy(gameObject);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
