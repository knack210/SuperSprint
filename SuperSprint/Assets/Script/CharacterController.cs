using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool isRunning;
    public float speed;
    public float jump;
    public GameObject goal;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 goalLocation;
    private Transform GroundTouch;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goalLocation = goal.transform.position;
        GroundTouch = this.transform.Find("GroundTouch");  
    }

    private void Update()
    {
        if (isRunning)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, goalLocation, speed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && IsOnGround())
        {
            Debug.Log("Grounded");
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }
    }

   private bool IsOnGround()
    {
        
        return Physics2D.OverlapCircle(GroundTouch.position, 0.1f,  groundLayer);
    }
}
