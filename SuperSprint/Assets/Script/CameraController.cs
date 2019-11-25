using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject follow;
    [SerializeField]
    private GameObject end;
	[SerializeField] private Transform distanceStop;


    //maxxxxxxxxxxxxxxxxxxxxxx
    [SerializeField]
    public Slider distanceSlider;

    private float offset;
    private float cameraEndPoint;
	private float playerEndPoint;

    // Sets object to follow and endpoint
    private void Start()
    {//maxxxxxxxxxxxxxxxxxxxxxxxxxx
        distanceSlider.value = 0;		

		offset = transform.position.x - follow.transform.position.x;
        cameraEndPoint = end.transform.position.x;
		playerEndPoint = distanceStop.position.x;
		distanceSlider.maxValue = Mathf.RoundToInt(playerEndPoint - follow.transform.position.x);

		UpdateText();
			   
    }

    // Follows assigned object until endpoint is reached
    private void LateUpdate()
    {
        if (transform.position.x < (cameraEndPoint - offset))
        {
            transform.position = new Vector3(follow.transform.position.x + offset, transform.position.y, transform.position.z);
            UpdateText();
        }
        distanceSlider.value = Mathf.RoundToInt(playerEndPoint - follow.transform.position.x);
		//Debug.Log(distanceSlider.value);
    }

    private void UpdateText()
    {
        //int distance = Mathf.RoundToInt(playerEndPoint - follow.transform.position.x);
        //distanceText.text = "Remaining distance: " + distance.ToString() + " >";		

        //maxxxxxxxxxxxxxxxxxx
        // distanceSlider.value = offset;
    }

    private void DisableText()
    {
        //distanceText.enabled = false;
    }
}
