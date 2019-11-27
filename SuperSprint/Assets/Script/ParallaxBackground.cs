using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
	private float length, startPoint;
	private Camera _camera;
	[SerializeField] private float parallaxSpeed;
	[SerializeField] private GameObject overRidePosition;
   
    private void Start()
    {
		_camera = Camera.main;
		if (overRidePosition == null)
		{
			startPoint = this.transform.position.x;
			length = this.GetComponent<SpriteRenderer>().bounds.size.x;
		}

		else
		{
			startPoint = overRidePosition.transform.position.x;
			length = overRidePosition.GetComponent<SpriteRenderer>().bounds.size.x;
		}
    }

	private void Update()
    {
		float temp = (_camera.transform.position.x * (1 - parallaxSpeed));
		float distance = (_camera.transform.position.x * parallaxSpeed);

		transform.position = new Vector3(startPoint + distance, transform.position.y, transform.position.z);

		if (temp > startPoint + length) startPoint += length;
		else if (temp < startPoint - length) startPoint -= length;
    }
}
