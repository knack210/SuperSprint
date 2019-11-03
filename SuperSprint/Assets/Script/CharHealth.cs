using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharHealth : MonoBehaviour
{
    private AudioSource source;
    //trashmax comment: changed health to 100f so its not null at start
    private float health = 100f;
    [SerializeField]
    private float maxHealth = 100f;

    //TrashMaxCode
   [SerializeField]
   private Image healthBar;

    [SerializeField]
    private Image powerBar;
    //TrashMaxCode

    [SerializeField]
    private GameObject PoorMansParticle;
 


    private float power;
    [SerializeField]
    private float maxPower = 100f;
    [SerializeField]
    private float powerCost;
    private float targetPower;
	[SerializeField]
	private int powerScore = 20;
    [SerializeField]
    private float regenRate;
    private float depletionRate = 0;
    private bool regenActive;
    [SerializeField]
    private float invincibleTime;
    private bool isInvincible;
    [SerializeField]
    private AudioClip powerSfx;
    //[SerializeField]
    //private Image healthBar;
    //[SerializieField]
    //private Image powerBar;

                     

   


    private void Start()
    {
        source = GetComponent<AudioSource>();

        //SetHealthBar(); for ui

        //TrashMaxCode

        SetHealthBar();
        SetPowerBar();
        //Trashmaxcode


       
        power = 0;
        regenActive = true;

        Debug.Log("Depeletion rate is " + depletionRate);
    }

    private void LateUpdate()
    {   
        if ((power < maxPower) && regenActive)
        {
            power = Mathf.MoveTowards(power, maxPower, regenRate * Time.deltaTime);
            SetPowerBar();
        }

        else if ((power > targetPower) && !regenActive)
        {
            power = Mathf.MoveTowards(power, targetPower, depletionRate);
            SetPowerBar();
			if (power == targetPower)
			{
				SendMessage("DisablePower");
			}
        }

        if (power >= powerCost)
        {
            // Flashing UI element indicating Power is available
            EnableParticleWhenPowerIsFull();
        }



        //trashmax
        if (power < powerCost)
        {
            DisableParticle();
        }


        if (Input.GetButtonDown("Power"))
        {
            AttemptPower();
        }
        
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            health -= damage;
			SendMessage("IsHurt");            
            SetHealthBar();
           

			SendMessage("SlideEnd");
            IsDead();
            // EnableInvincibility();

            // Invoke(nameof(DisableInvincibility), invincibleTime);
        }
    }

    private void IsDead()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    //updating ui healthbar
    private void SetHealthBar()
    {
        //trashmaxcode
        healthBar.fillAmount = health / maxHealth;
        //trashmaxcode
    }
    //trashmaxcode

    private void SetPowerBar()
    {
        powerBar.fillAmount = power / maxPower;
    }
    //trashmaxcode    

	public void EnableInvincibility()
    {
        isInvincible = true;
    }

    public void DisableInvincibility()
    {
        isInvincible = false;
    }

    public void AttemptPower()
    {
        if (power >= powerCost)
        {
            source.PlayOneShot(powerSfx);            
			Camera.main.SendMessage("AddScore", powerScore);
            SendMessage("ActivatePower");
            //power -= powerCost;
            targetPower = power - powerCost;
        }
    }

    public void EnableRegen()
    {
        regenActive = true;
    }

    public void DisableRegen()
    {
        regenActive = false;
    }

    public void SetDepletionRate(float dRate)
    {
        depletionRate = dRate;
    }


    public void EnableParticleWhenPowerIsFull()
    {
        PoorMansParticle.SetActive(true);
    }

    public void DisableParticle()
    {
        PoorMansParticle.SetActive(false);
    }

    public void RestoreHealth(float amt)
    {
        if ((health + amt) < maxHealth)
        {
            health = health + amt;
        }

        else
        {
            health = maxHealth;
        }

        SetHealthBar();
    }

    public void RestorePower(float amt)
    {
        if ((power + amt) < maxPower)
        {
            power = power + amt;
        }

        else
        {
            power = maxPower;
        }

        SetPowerBar();
    }
}
