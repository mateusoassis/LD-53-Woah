using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    [SerializeField] private PlayerSkills skill;
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private GameObject parent;
    [SerializeField] private Transform rotationTransform;
    [SerializeField] private float totalRange;
    // max 180
    void Awake()
    {
        skill.ZeroCooldownTimer();
        transform.localScale = new Vector3(skill.skillArray.skillRadius, skill.skillArray.skillRadius, 1f);
        playerStatus = GameObject.Find("DestinationPoint").GetComponent<PlayerStatus>();
        Destroy(parent, skill.skillArray.skillCooldown);
        GameObject.Find("SoundManager").GetComponent<AudioClipManager>().PlayOneShot("DealDamage");
    }

    void Start()
    {
        float u = Random.Range(-totalRange/2, totalRange/2);
        rotationTransform.Rotate(0f, 0f, u);
    }

    void Update()
    {
        /*
        if(skill.skillArray.skillCooldownTimer <= skill.skillArray.skillCooldown)
        {
            skill.skillArray.skillCooldownTimer += Time.deltaTime;
            // RefreshCooldown no controle da interface
        }
        else 
        */
        if(skill.skillArray.skillCooldownTimer > skill.skillArray.skillCooldown)
        {
            skill.skillArray.canCast = true;
            //Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("GorduraPlus"))
        {
            //playerStatus.HasteResetCooldown();
            playerStatus.TakeDamage(1);
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
