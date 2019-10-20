using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharHealth : MonoBehaviour
{    
    private CharacterController characterController;   
    
    //trashmax comment: changed health to 100f so its not null at start
    private float health=100f;
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
	[SerializeField]
	private Text healthText;
    [SerializeField]
    private Text powerText;
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


        health = maxHealth;
        power = 0;
        regenActive = true;
        characterController = GetComponent<CharacterController>();
		UpdateUI();
        UpdateMeter();

    
    }










    private void LateUpdate()
    {
   
        if ((power < maxPower) && regenActive)
        {
            power = Mathf.MoveTowards(power, maxPower, regenRate * Time.deltaTime);
            UpdateMeter();

            //trashmaxcode
            SetPowerBar();
            //trashmaxcode

        }

        if (power >= powerCost)
        {
            // Flashing UI element indicating Power is available
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            //SetHealthBar();
                                //trashmaxcode
                                SetHealthBar();
                                //trashmaxcode

    SendMessage("SlideEnd");
            IsDead();
            EnableInvincibility();
			UpdateUI();
            Invoke(nameof(DisableInvincibility), invincibleTime);
        }
    }

    private void IsDead()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("TutorialLevel");
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
			UpdateMeter();
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

	private void UpdateUI()
	{
		string remainingHealth = (health / 20f).ToString();
		healthText.text = remainingHealth;



    }

    private void UpdateMeter()
    {
        powerText.text = Mathf.RoundToInt(power).ToString() + "%";
    }



}
