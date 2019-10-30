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
    /*
    [SerializeField]
    private BoxCollider2D standCol;
	[SerializeField]
	private BoxCollider2D jumpCol;
    [SerializeField]
    private BoxCollider2D slideCol;
    */
    private AudioSource source;
    [SerializeField]
    private AudioClip jumpSfx;
    [SerializeField]
    private AudioClip slideSfx;
    [SerializeField]
    private AudioClip hurtSfx;

    private void Start()
    {
        isRunning = true;
        source = GetComponent<AudioSource>();
        source.volume = source.volume * PlayerPrefs.GetInt("isSound");
        anim = GetComponent<Animator>();        
        rb = GetComponent<Rigidbody2D>();
        goalLocation = goal.transform.position;
        GroundTouch = this.transform.Find("GroundTouch");
		// jumpCol.enabled = false;
        // slideCol.enabled = false;
    }

    private void Update()
    {    
        if (isRunning)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, goalLocation, speed * Time.deltaTime);           
        }

        if (IsOnGround() && anim.GetBool("isJump"))
        {
            anim.SetBool("isJump", false);
			//jumpCol.enabled = false;
			//standCol.enabled = true;
        }
        
        if (Input.GetButtonDown("Jump") && IsOnGround())
        {
            if (isSliding)
			{
				SlideEnd();
				//slideCol.enabled = false;
			}

            // source.PlayOneShot(jumpSfx);
            anim.SetBool("isJump", true);
			//jumpCol.enabled = true;
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
        // source.PlayOneShot(slideSfx);
        Debug.Log("Sliding");
        anim.SetBool("isSlide", true);
        isSliding = true;
        //standCol.enabled = false;
        //slideCol.enabled = true;
        Invoke("SlideEnd", slideTime);
    }

    public void SlideEnd()
    {
        Debug.Log("Not sliding");
        CancelInvoke("SlideEnd");
        anim.SetBool("isSlide", false);
        //standCol.enabled = true;
        //slideCol.enabled = false;
        isSliding = false;        
    }    

	public void StopRunning()
	{
		isRunning = false;
	}

	public void IsHurt()
	{
        source.PlayOneShot(hurtSfx);
		anim.SetTrigger("isHurt");
	}
}
