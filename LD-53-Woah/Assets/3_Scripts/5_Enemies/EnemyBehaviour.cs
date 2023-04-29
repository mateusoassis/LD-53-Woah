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
    
    void Start()
    {
        destinationPoint = GameObject.Find("DestinationPoint").transform;
        playerStatusScript = destinationPoint.transform.GetComponent<PlayerStatus>();
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 a = transform.position;
        Vector2 b = destinationPoint.position;
        transform.position = Vector2.MoveTowards(a, b, enemySpeed * Time.fixedDeltaTime);
    }

    public void EnemyTakeDamage(int damageTaken)
    {
        enemyCurrentHealth -= damageTaken;
        if(enemyCurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
