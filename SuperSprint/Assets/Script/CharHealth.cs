using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharHealth : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;
    [SerializeField]
    private float health = 100f;
    private float maxHealth;
    //[SerializeField]
    //private Image healthBar;

    private void Start()
    {
        //SetHealthBar(); for ui
        maxHealth = health;
        characterController = FindObjectOfType<CharacterController>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        //SetHealthBar();
        IsDead();
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
}
