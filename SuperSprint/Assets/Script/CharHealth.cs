using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharHealth : MonoBehaviour
{  
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
 


    private float power;
    [SerializeField]
    private float maxPower = 100f;
    [SerializeField]
    private float powerCost;
	[SerializeField]
	private int powerScore = 20;
    [SerializeField]
    private float regenRate;
    private bool regenActive;
    [SerializeField]
    private float invincibleTime;
    private bool isInvincible;
    //[SerializeField]
    //private Image healthBar;
    //[SerializieField]
    //private Image powerBar;

                     

   


    private void Start()
    {


        //SetHealthBar(); for ui

        //TrashMaxCode
      
        SetHealthBar();
        SetPowerBar();
        //Trashmaxcode


       
        power = 0;
        regenActive = true;    
    }

    private void LateUpdate()
    {
   
        if ((power < maxPower) && regenActive)
        {
            power = Mathf.MoveTowards(power, maxPower, regenRate * Time.deltaTime);


            //trashmaxcode
            SetPowerBar();
            //trashmaxcode

        }

        if (power >= powerCost)
        {
            // Flashing UI element indicating Power is available
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
            EnableInvincibility();

            Invoke(nameof(DisableInvincibility), invincibleTime);
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
            power -= powerCost;
			Camera.main.SendMessage("AddScore", powerScore);
            SendMessage("ActivatePower");
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
}
