using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveController : MonoBehaviour
{
	[SerializeField] private float shockwaveSpeed;
	[SerializeField] private float pointsAwardedPerHit;
	private Camera _camera;

	private int numTargetsHit;

	private void Start()
	{
		_camera = Camera.main;
		numTargetsHit = 0;
	}

	private void Update()
	{
		this.transform.position = Vector2.MoveTowards(this.transform.position, Destination(),shockwaveSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Collision generated");
		if (other.CompareTag("Enemy"))
		{
			//Debug.Log("Hit");
			other.SendMessage("HitByShockwave");
			numTargetsHit++;
		}

		if (other.CompareTag("Obstacle"))
		{
			Debug.Log("Sending to obstacle");
			other.SendMessage("HitByShockwave");
			numTargetsHit++;
		}
	}

	private void OnBecameInvisible()
	{
		_camera.SendMessage("AddScore", ((float)numTargetsHit * pointsAwardedPerHit));
		Destroy(this.gameObject, Time.deltaTime);
	}

	private Vector2 Destination()
	{
		return new Vector2(this.transform.position.x + 1000, this.transform.position.y);
	}
}
