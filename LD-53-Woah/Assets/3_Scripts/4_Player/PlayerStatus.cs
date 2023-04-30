using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int totalHealth;
    public int currentHealth;
    public Shake cameraShake;

    public int numOfBars;

    public Image[] healthBars;
    public Sprite greenBar;
    public Sprite dimBar;

    [SerializeField] private SkillHandler skillHandler;

    void Start()
    {
        currentHealth = totalHealth;
    }

    void Update()
    {

        if(totalHealth > numOfBars)
        {
            totalHealth = numOfBars;
        }

        for(int i = 0; i < healthBars.Length; i++)
        {
            if(i< totalHealth)
            {
                healthBars[i].sprite = greenBar;
            }
            else{
                healthBars[i].sprite = dimBar;
            }

            if(i < numOfBars)
            {
                healthBars[i].enabled = true;
            }
            else
            {
                healthBars[i].enabled = false;
            }
        }
    }

    public void TakeDamage(int a) 
    {
        currentHealth = currentHealth - a;
        cameraShake.CallShake(cameraShake.shakeDuration, cameraShake.shakeMagnitude);
    }

    public void Heal(int b)
    {
        currentHealth = currentHealth + b;
    }

    public void DestroyResetCooldown()
    {
        skillHandler.skillUI[0].skill.skillArray.skillCooldownTimer = skillHandler.skillUI[0].skill.skillArray.skillCooldown;
        skillHandler.skillUI[0].skill.skillArray.canCast = true;
    }
    public void FreezeResetCooldown()
    {
        // skill index 1
        skillHandler.skillUI[1].skill.skillArray.skillCooldownTimer = skillHandler.skillUI[1].skill.skillArray.skillCooldown;
        skillHandler.skillUI[1].skill.skillArray.canCast = true;
    }
    public void HasteResetCooldown()
    {
        // skill index 2
        skillHandler.skillUI[2].skill.skillArray.skillCooldownTimer = skillHandler.skillUI[2].skill.skillArray.skillCooldown;
        skillHandler.skillUI[2].skill.skillArray.canCast = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Destroy CD Reset");
            TakeDamage(other.gameObject.transform.GetComponent<EnemyBehaviour>().damage);
            DestroyResetCooldown();
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("Vitamin"))
        {
            Debug.Log("Freeze CD Reset");
            FreezeResetCooldown();
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("GorduraPlus"))
        {
            Debug.Log("Haste CD Reset");
            HasteResetCooldown();
            Destroy(other.gameObject);
        }
    }
}
