using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFlopsPower : MonoBehaviour
{
    [SerializeField]
    private GameObject lazer;
    [SerializeField]
    private Transform laserSpawn; 
    [SerializeField]
    private float cooldownTime;
    private float cooldownWindow = 0;
    [SerializeField]
    private LayerMask enemyLayer;

    private RaycastHit2D target;

    private void Start()
    {
        this.SendMessage("DepletionRate", 100);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Power"))
        {
            SendMessage("AttemptPower");
        }
    }

    private void ActivatePower()
    {
        target = Physics2D.BoxCast(Vector2.zero, BoxSize(), 0, Vector2.right, Screen.width, enemyLayer);
        if (target && (cooldownWindow < Time.time))
        {
            // Left off here
        }

        else
        {

        }
    }

    private Vector2 BoxSize()
    {
        return new Vector2(0.1f, Screen.height);
    }
}
