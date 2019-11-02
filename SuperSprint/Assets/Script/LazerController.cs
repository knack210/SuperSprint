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

    private void Update()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, target.transform.position, lazerSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Destroy(other.gameObject);
            Camera.main.SendMessage("AddScore", pointsAwarded);
            Destroy(this, Time.deltaTime);
        }
    }

    private void SetTarget (GameObject hit)
    {
        target = hit;
    }
        
}
