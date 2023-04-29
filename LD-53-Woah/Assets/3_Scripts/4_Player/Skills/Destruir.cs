using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    [SerializeField] private PlayerSkills skill;
    
    void Awake()
    {
        skill.ZeroTimer();
    }

    void Update()
    {
        skill.skillArray.skillDurationTimer += Time.deltaTime;
        if(skill.skillArray.skillDurationTimer > skill.skillArray.skillDuration)
        {
            Destroy(this.gameObject);
        }
    }
}
