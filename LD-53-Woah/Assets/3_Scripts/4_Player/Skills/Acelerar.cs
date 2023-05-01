using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerar : MonoBehaviour
{
    [SerializeField] private PlayerSkills skill;
    void Awake()
    {
        skill.ZeroCooldownTimer();
        transform.localScale = new Vector3(skill.skillArray.skillRadius, skill.skillArray.skillRadius, 1f);
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
            Destroy(this.gameObject);
        }
    }
}
