using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
	private float length, startPoint;
	private Camera _camera;
	[SerializeField] private float parallaxSpeed;
   
    private void Start()
    {
		_camera = Camera.main;
		startPoint = transform.position.x;
		length = GetComponent<SpriteRenderer>().bounds.size.x;
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
