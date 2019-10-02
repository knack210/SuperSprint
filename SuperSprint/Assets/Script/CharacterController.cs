using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public bool isRunning;
    public float speed;
    public GameObject goal;

    private Vector2 goalLocation;

    private void Start()
    {
        goalLocation = goal.transform.position;    
    }

    private void Update()
    {
        if (isRunning)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, goalLocation, speed * Time.deltaTime);
        }
    }
}
