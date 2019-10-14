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

    private void Update()
    {    
        if (isRunning)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, goalLocation, speed * Time.deltaTime);           
        }

        if (IsOnGround())
        {
            anim.SetBool("isJump", false);
        }
        
        if (Input.GetButtonDown("Jump") && IsOnGround())
        {
            if (isSliding) { SlideEnd();  }            
            Debug.Log("Grounded");
            anim.SetBool("isJump", true);
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Slide") && IsOnGround() && !isSliding)
        {
            SlideStart();
        }
    }

   private bool IsOnGround()
    {
        
        return Physics2D.OverlapCircle(GroundTouch.position, 0.1f,  groundLayer);
    }

    private void SlideStart()
    {
        Debug.Log("Sliding");
        anim.SetBool("isSlide", true);
        isSliding = true;
        standCol.enabled = false;
        slideCol.enabled = true;
        Invoke("SlideEnd", slideTime);
    }

    public void SlideEnd()
    {
        Debug.Log("Not sliding");
        CancelInvoke("SlideEnd");
        anim.SetBool("isSlide", false);
        standCol.enabled = true;
        slideCol.enabled = false;
        isSliding = false;        
    }    

	public void StopRunning()
	{
		isRunning = false;
	}
}
