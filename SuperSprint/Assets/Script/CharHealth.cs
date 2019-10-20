using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharHealth : MonoBehaviour
{    
    private CharacterController characterController;    
    private float health;
    [SerializeField]
    private float maxHealth = 100f;

    //TrashMaxCode
   [SerializeField]
   Image healthBar;
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
        healthBar = GetComponent<Image>();
        //Trashmax

        health = maxHealth;
        power = 0;
        regenActive = true;
        characterController = GetComponent<CharacterController>();
		UpdateUI();
        UpdateMeter();

    
    }










    private void LateUpdate()
    {
        //trashmax
        healthBar.fillAmount = health / maxHealth;
        //trashmax



        if ((power < maxPower) && regenActive)
        {
            power = Mathf.MoveTowards(power, maxPower, regenRate * Time.deltaTime);
            UpdateMeter();
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

                            

}

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
