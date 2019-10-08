using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private bool isRunning;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private GameObject goal;
    [SerializeField]
    private LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 goalLocation;
    private Transform GroundTouch;
    [SerializeField]
    private BoxCollider2D standCol;
    [SerializeField]
    private BoxCollider2D slideCol;

    private void Start()
    {
        isRunning = true;
        rb = GetComponent<Rigidbody2D>();
        goalLocation = goal.transform.position;
        GroundTouch = this.transform.Find("GroundTouch");
        slideCol.enabled = false;
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
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && IsOnGround())
        {
            slideStart();
        }
    }

   private bool IsOnGround()
    {
        
        return Physics2D.OverlapCircle(GroundTouch.position, 0.1f,  groundLayer);
    }

    private void slideStart()
    {
        Debug.Log("Sliding");
        standCol.enabled = false;
        slideCol.enabled = true;
        Invoke("slideEnd", 2);
    }

    private void slideEnd()
    {
        Debug.Log("Not sliding");
        standCol.enabled = true;
        slideCol.enabled = false;
    }
}
