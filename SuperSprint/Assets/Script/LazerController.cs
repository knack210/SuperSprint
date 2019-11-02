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
        if (target != null)
        {
           this.transform.position = Vector2.MoveTowards(this.transform.position, FindTarget(), lazerSpeed * Time.deltaTime);
            Debug.Log(this.transform.position);
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Ouch");
            other.SendMessage("HitByLaser");
            Camera.main.SendMessage("AddScore", pointsAwarded);
            Destroy(this.gameObject, Time.deltaTime);
        }
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
