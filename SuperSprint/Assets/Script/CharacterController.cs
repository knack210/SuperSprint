using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private bool isRunning;
    private bool isSliding;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float slideTime;
    [SerializeField]
    private GameObject goal;
    [SerializeField]
    private LayerMask groundLayer;
    

    private Rigidbody2D rb;
    private Vector2 goalLocation;
    private Transform GroundTouch;
    private Animator anim;
    [SerializeField]
    private BoxCollider2D standCol;
    [SerializeField]
    private BoxCollider2D slideCol;

    private void Start()
    {
        isRunning = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        goalLocation = goal.transform.position;
        GroundTouch = this.transform.Find("GroundTouch");
        slideCol.enabled = false;
    }

    private void LateUpdate()
    {
        

        if (isRunning)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, goalLocation, speed * Time.deltaTime);           
        }

        if (IsOnGround())
        {
            anim.SetBool("isJump", false);
        }
        
        if (Input.GetButtonDown("Jump") && IsOnGround() && !isSliding)
        {
            Debug.Log("Grounded");
            anim.SetBool("isJump", true);
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && IsOnGround() && !isSliding)
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
        anim.SetBool("isSlide", true);
        isSliding = true;
        standCol.enabled = false;
        slideCol.enabled = true;
        Invoke("slideEnd", slideTime);
    }

    private void slideEnd()
    {
        Debug.Log("Not sliding");
        standCol.enabled = true;
        slideCol.enabled = false;
        isSliding = false;
        anim.SetBool("isSlide", false);
    }
}
