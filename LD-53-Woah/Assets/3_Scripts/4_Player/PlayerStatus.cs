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

    public void TakeDamage() 
    {
        currentHealth = currentHealth - 10;
    }

    private void OnTriggerEnter2d(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Chegou");
            TakeDamage();
            Destroy(other.gameObject);
        }
    }
}
