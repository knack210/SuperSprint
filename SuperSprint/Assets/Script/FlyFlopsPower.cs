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
    private LayerMask enemyLayer;

    private RaycastHit2D target;

    private void Update()
    {
        if (Input.GetButtonDown("Power"))
        {
            SendMessage("AttemptPower");
        }
    }

    private void ActivatePower()
    {
        target = Physics2D.BoxCast(
                 (Vector2)this.transform.position,
                 new Vector2(100, 100),
                 0,
                 new Vector2(0, 0),
                 100,
                 enemyLayer);
    }
}
