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
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        SendMessage("SetDepletionRate", (100 / invisTime) * Time.fixedDeltaTime);
    }    

    public void ActivatePower()
    {        
        invisible = true;
        sprite.color = new Color(1f, 1f, 1f, .5f);        
        SendMessage("EnableInvincibility");
        SendMessage("DisableRegen");
        // Invoke("DisablePower", invisTime);
    }

    public void DisablePower()
    {
        SendMessage("DisableInvincibility");
        SendMessage("EnableRegen");
        invisible = false;
        sprite.color = new Color(1f, 1f, 1f, 1f);
    }

    public void TakeDamage(float damage)
    {        
        if (invisible)
        {
            Camera.main.SendMessage("AddScore", invisScore);
        }
    }

    // Ugly function to fix Invisibill
    public void InvisibillDisableInvincibility()
    {
        if (!invisible)
        {
            Debug.Log("Not invisible");
            SendMessage("DisableInvincibility");
        }

    }
}
