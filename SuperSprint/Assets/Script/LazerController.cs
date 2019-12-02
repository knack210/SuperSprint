using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour
{
    [SerializeField]
    private float lazerSpeed;
    [SerializeField]
    private float pointsAwarded;
    private GameObject target;
	private Camera _camera;

	private void Start()
	{
		_camera = Camera.main;
	}

	private void Update()
    {
        if (target != null)
        {
           this.transform.position = Vector2.MoveTowards(this.transform.position, FindTarget(), lazerSpeed * Time.deltaTime);
            //Debug.Log(this.transform.position);
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enemy") && _camera != null)
        {
            Debug.Log("Ouch");
            other.SendMessage("HitByLaser");
            _camera.SendMessage("AddScore", pointsAwarded);
            Destroy(this.gameObject, Time.deltaTime);
        }
    }

	private void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}

	private void SetTarget (GameObject hit)
    {
        target = hit;        
    }

    private Vector2 FindTarget()
    {
        return target.transform.position;
    }
}
