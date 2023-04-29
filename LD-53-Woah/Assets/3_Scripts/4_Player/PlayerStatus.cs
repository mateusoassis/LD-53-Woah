using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int totalHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = totalHealth;
    }

    public void TakeDamage(int a) 
    {
        currentHealth = currentHealth - a;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Chegou");
            TakeDamage(other.gameObject.transform.GetComponent<EnemyBehaviour>().damage);
            Destroy(other.gameObject);
        }
    }
}