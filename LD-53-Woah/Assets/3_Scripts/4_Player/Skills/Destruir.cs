using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    [SerializeField] private PlayerSkills skill;
    [SerializeField] private PlayerStatus playerStatus;
    void Awake()
    {
        skill.ZeroCooldownTimer();
        transform.localScale = new Vector3(skill.skillArray.skillRadius, skill.skillArray.skillRadius, 1f);
        playerStatus = GameObject.Find("DestinationPoint").GetComponent<PlayerStatus>();
    }

    void Update()
    {
        if(skill.skillArray.skillCooldownTimer <= skill.skillArray.skillCooldown)
        {
            skill.skillArray.skillCooldownTimer += Time.deltaTime;
            // RefreshCooldown no controle da interface
        }
        else if(skill.skillArray.skillCooldownTimer > skill.skillArray.skillCooldown)
        {
            skill.skillArray.canCast = true;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("GorduraPlus"))
        {
            playerStatus.HasteResetCooldown();
            Destroy(other.gameObject);
            GetComponent<CircleCollider2D>().enabled = false;
        }
        else if(other.gameObject.CompareTag("Vitamin"))
        {
            playerStatus.TakeDamage(other.gameObject.transform.GetComponent<EnemyBehaviour>().damage);
            Destroy(other.gameObject);
            GetComponent<CircleCollider2D>().enabled = false;
        }
        else if(other.gameObject.CompareTag("Gordura"))
        {
            playerStatus.DestroyResetCooldown();
            Destroy(other.gameObject);
            GetComponent<CircleCollider2D>().enabled = false;
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            playerStatus.DestroyResetCooldown();
            Destroy(other.gameObject);
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
