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
    public float enemyRealSpeed;
    //public PlayerStatus playerStatusScript;
    public Transform destinationPoint;
    public Transform finalDestinationPoint;
    public GameObject destroyParticle;
    public PlayerStatus playerStatus;

    public int locationsInTotal;

    int destinationIndex;

    public Transform[] locations;

    [Header("Factors")]
    public float hasteFactor;
    public float hasteDuration;
    public float hasteDurationTimer;
    public float freezeFactor;
    public float freezeDuration;
    public float freezeDurationTimer;
    public float factor;

    [Header("Flags")]
    public bool freeze;
    public bool haste;
    
    void Awake()
    {
        playerStatus = GameObject.Find("DestinationPoint").GetComponent<PlayerStatus>();
    }

    void Start()
    {
        locationsInTotal = locations.Length;
        destinationPoint = locations[0];
        finalDestinationPoint = GameObject.Find("DestinationPoint").GetComponent<Transform>();
        //playerStatus = GameObject.Find("DestinationPoint").GetComponent<PlayerStatus>();
        //playerStatusScript = destinationPoint.transform.GetComponent<PlayerStatus>();
        enemyCurrentHealth = enemyMaxHealth;
        enemyRealSpeed = enemySpeed;
    }

    private void Update()
    {
        SwitchDestination();
        HandleFactor();
        //HandleStatus();
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
            if(destinationIndex >= locationsInTotal)
            {
                destinationIndex = 0;
            }
            destinationPoint = locations[destinationIndex];
        }
        else
        {
            //Debug.Log(destinationIndex);
            transform.position = Vector2.MoveTowards(transform.position, destinationPoint.position, enemyRealSpeed * factor * Time.deltaTime);
        }
    }
    
    public void HandleFactor()
    {
        float factorBase = 1;
        if(freeze)
        {
            if(haste)
            {
                factor = (factorBase * hasteFactor) / freezeFactor;
            }
            else if(!haste)
            {
                factor = factorBase / freezeFactor;
            }
            
        }
        else if(!freeze)
        {
            if(haste)
            {
                factor = factorBase * hasteFactor;
            }
            else if(!haste)
            {
                factor = factorBase;
            }
        }
    }
    
    /*
    public void HandleStatus()
    {
        if(freeze)
        {
            freezeDurationTimer += Time.deltaTime;
            if(freezeDurationTimer > freezeDuration)
            {
                freezeDurationTimer = 0;
                freeze = false;
            }
        }
        if(haste)
        {
            hasteDurationTimer += Time.deltaTime;
            if(hasteDurationTimer > hasteDuration)
            {
                hasteDurationTimer = 0;
                haste = false;
            }
        }
    }
    */

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Freeze")
        {
            freeze = true;
        }
        else if(other.gameObject.tag == "Haste")
        {
            haste = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Freeze")
        {
            freeze = false;
        }
        else if(other.gameObject.tag == "Haste")
        {
            haste = false;
        }
    }

    private void OnDestroy()
    {
        GameObject explosion = Instantiate(destroyParticle, transform.position, transform.rotation);
        playerStatus.enemyCounter--;
    }
}
