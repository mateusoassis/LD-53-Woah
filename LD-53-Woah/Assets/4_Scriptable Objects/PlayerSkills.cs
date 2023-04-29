using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkills", menuName = "PlayerSkills", order = 0)]
public class PlayerSkills : ScriptableObject
{
    [System.Serializable]
    public class skillData
    {
        [Header("Info")]
        public int skillIndex;
        public string skillName;
        
        [Header("Damage and Area")]
        public float skillDamage;
        public float skillRadius;

        [Header("Time Related")]
        public float skillDuration;
        public float skillCooldown;

        [Header("Sound")]
        public AudioClip skillSound;
        
        [Header("Ignore")]
        public GameObject skillPrefab;
        public float skillCooldownTimer;
        public float skillDurationTimer;
    }
    public skillData skillArray;

    /*
    public void CastSkill(int a, Vector3 transformPosition)
    {
        if(a == 0)
        {
            CastDestruir(transformPosition);
        }
        else if(a == 1)
        {
            CastCongelar(transformPosition);
        }
        else if(a == 2)
        {
            CastAcelerar(transformPosition);
        }
    }

    public void CastDestruir(Vector3 skillTransformPosition)
    {
        // index 0
        GameObject clone = Instantiate(skillsArray[0].skillPrefab, skillTransformPosition, Quaternion.identity);
    }

    public void CastCongelar(Vector3 skillTransformPosition)
    {
        // index 1
        GameObject clone = Instantiate(skillsArray[1].skillPrefab, skillTransformPosition, Quaternion.identity);
    }

    public void CastAcelerar(Vector3 skillTransformPosition)
    {
        // index 2
        GameObject clone = Instantiate(skillsArray[2].skillPrefab, skillTransformPosition, Quaternion.identity);
    }

    public void ZeroTimers()
    {
        for(int i = 0; i < skillsArray.Length; i++)
        {
            skillsArray[i].skillCooldownTimer = skillsArray[i].skillCooldown;
        }
    }
    */
    public void ZeroTimer()
    {
        skillArray.skillCooldownTimer = skillArray.skillCooldown;
    }
}
