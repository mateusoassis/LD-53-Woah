using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float enemySpeed;
    public int enemyMaxHealth;
    public int enemyCurrentHealth;
    public int damage;

    [Header("Enemy References")]
    public PlayerStatus playerStatusScript;
    public Transform destinationPoint;

    public int locationsInTotal;

    int destinationIndex;

    public Transform[] locations;
    
    void Start()
    {
        locationsInTotal = locations.Length;
        destinationPoint = locations[0];
        playerStatusScript = destinationPoint.transform.GetComponent<PlayerStatus>();
        enemyCurrentHealth = enemyMaxHealth;
    }


    private void Update()
    {
        SwitchDestination();
    }

    public void EnemyTakeDamage(int damageTaken)
    {
        enemyCurrentHealth -= damageTaken;
        if(enemyCurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void SwitchDestination()
    {
        if(transform.position == destinationPoint.transform.position) 
        {
            destinationIndex++;
            if(destinationIndex >= locations.Length)
            {
                destinationIndex = 0;
            }
            destinationPoint = locations[destinationIndex];
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, destinationPoint.position, enemySpeed * Time.deltaTime);
        }
    }
}
