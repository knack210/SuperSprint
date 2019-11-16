using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyFlopsPower : MonoBehaviour
{
    [SerializeField]
    private GameObject lazer;
    [SerializeField]
    private Transform lazerSpawn;     
    [SerializeField]
    private float cooldownTime;
    private float cooldownWindow = 0;
    [SerializeField]
    private LayerMask enemyLayer;
	private Camera _camera;

    private RaycastHit2D target;

    private void Start()
    {
		_camera = Camera.main;
        this.SendMessage("SetDepletionRate", 100);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Power"))
        {
            SendMessage("AttemptPower");
        }
    }

    public void ActivatePower()
    {
        target = Physics2D.BoxCast(Vector2.zero, BoxSize(), 0, Vector2.right, _camera.scaledPixelWidth, enemyLayer);
        if (target && (cooldownWindow < Time.time))
        {
            Debug.Log("DetectedEnemy");
            this.SendMessage("DisableRegen");            
            GameObject lazerInstance = Instantiate(lazer, lazerSpawn.position, Quaternion.identity) as GameObject;
            lazerInstance.name = "LazerShot";
            lazerInstance.SendMessage("SetTarget", target.transform.gameObject);
            cooldownWindow = Time.time + cooldownTime;
        }

        else if (!target)
        {
            Debug.Log("Miss");
        }
    }

    public void DisablePower()
    {
        this.SendMessage("EnableRegen");
    }
    
    private Vector2 BoxSize()
    {
        return new Vector2(0.1f, Screen.height);
    }
}
