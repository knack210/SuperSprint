using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField]
    private float amount;
    [SerializeField]
    private float scoreAward;
    [SerializeField]
    private bool restoreHealth;
    [SerializeField]
    private bool restorePower;
    [SerializeField]
    private float floatAmp;
    [SerializeField]
    private float floatFreq;

    private Vector2 startingPosition;
    private Vector2 temporaryPosition;

    private void Start()
    {
        startingPosition = this.transform.position;
    }

    private void Update()
    {
        temporaryPosition = startingPosition;
        temporaryPosition.y += Mathf.Sin(Time.fixedTime * Mathf.PI * floatFreq) * floatAmp;

        this.transform.position = temporaryPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (restoreHealth)
            {
                other.SendMessage("RestoreHealth", amount);
            }

            if (restorePower)
            {
                other.SendMessage("RestorePower", amount);
            }

            Camera.main.SendMessage("AddScore", scoreAward);
            Destroy(this.gameObject);
        }
    }
}
