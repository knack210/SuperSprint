using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibillPower : MonoBehaviour
{
    private bool invisible;
    [SerializeField]
    private int invisScore;
    [SerializeField]
    private float invisTime;
    private SpriteRenderer sprite;
	private AudioSource source;


    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
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
        invisible = true;
        sprite.color = new Color(1f, 1f, 1f, .5f);
        SendMessage("EnableInvincibility");
        SendMessage("DisableRegen");
        Invoke("DisablePower", invisTime);
    }

    private void DisablePower()
    {
        SendMessage("DisableInvincibility");
        SendMessage("EnableRegen");
        invisible = false;
        sprite.color = new Color(1f, 1f, 1f, 1f);
    }

    public void TakeDamage()
    {
        if (invisible)
        {
            Camera.main.SendMessage("AddScore", invisScore);
        }
    }
}
