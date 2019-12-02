using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapAttack : MonoBehaviour
{
	private float leapDestination;
	[SerializeField]
	private float leapHeight;
	[SerializeField]
	private float leapSpeed;
	[SerializeField]
	private float detectionRange;
	[SerializeField]
	private LayerMask playerLayer;


	private Animator anim;
	private bool attackPlayer = false;

	private void Start()
	{
		anim = this.GetComponent<Animator>();
		leapDestination = this.transform.position.y + leapHeight;
	}

	private void LateUpdate()
	{
		if (!attackPlayer)
		{
			if (Physics2D.BoxCast(RaySpawnPoint(), BoxSize(), 0, Vector2.left, detectionRange, playerLayer))
			{
				Debug.Log("Detected player");
				attackPlayer = true;
				anim.SetBool("SetLeap", true);
				this.SendMessage("PlaySound");
				this.SendMessage("AttackOverride");				
			}
		}

		if (attackPlayer && (this.transform.position.y < leapDestination))
		{
			this.transform.position = Vector2.MoveTowards(this.transform.position, LeapVector(), leapSpeed * Time.deltaTime);
		}
	}

	private Vector2 BoxSize()
	{
		return new Vector2(2, Screen.height);
	}

	private Vector2 RaySpawnPoint()
	{
		float xComponent = this.transform.position.x;
		float yComponent = 0;

		return new Vector2(xComponent, yComponent);
	}

	private Vector2 LeapVector()
	{
		return new Vector2(this.transform.position.x - leapHeight, leapDestination);
	}
}
