using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField]
	private GameObject follow;
    [SerializeField]
    private GameObject end;

    private float offset;
    private float endPoint;

    // Sets object to follow and endpoint
    private void Start()
    {
        offset = transform.position.x - follow.transform.position.x;
        endPoint = end.transform.position.x;
    }

    // Follows assigned object until endpoint is reached
    private void LateUpdate()
    {
        if (transform.position.x < (endPoint - offset))
        {
            transform.position = new Vector3(follow.transform.position.x + offset, transform.position.y, transform.position.z);
        }
    }
}
