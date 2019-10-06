using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private bool Walking, Flying;
    public GameObject EnemyType;

    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private float spawnInterval = 3f, enemySpeed = 5f, frequencyFlight = 15f, magnitudeFlight = 0.5f;    
    private float elapsedTime = 0f;
    private GameObject newEnemy;

    private void Start()
    {
        
    }


    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= spawnInterval)
        {
            Debug.Log("here");
            newEnemy = Instantiate(EnemyType, this.transform.position, this.transform.rotation);
            newEnemy.SendMessage("SetSpeed", enemySpeed);
            newEnemy.SendMessage("SetDamage", damage);

            if (Flying)
            {
                newEnemy.SendMessage("SetMagnitude", magnitudeFlight);
                newEnemy.SendMessage("SetFrequency", frequencyFlight);
            }
            elapsedTime = 0f;
        }
    }
}
