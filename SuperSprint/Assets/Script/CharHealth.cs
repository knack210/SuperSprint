using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharHealth : MonoBehaviour
{    
    private CharacterController characterController;
    [SerializeField]
    private float health = 100f;
    private float maxHealth;
    [SerializeField]
    private float invincibleTime;
    private bool isInvincible;
    //[SerializeField]
    //private Image healthBar;

    private void Start()
    {
        //SetHealthBar(); for ui
        maxHealth = health;
        characterController = GetComponent<CharacterController>();
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            //SetHealthBar();
            IsDead();
            isInvincible = true;
            Invoke(nameof(SetInvincibility), invincibleTime);
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

    private void SetInvincibility()
    {
        isInvincible = false;
    }
}
