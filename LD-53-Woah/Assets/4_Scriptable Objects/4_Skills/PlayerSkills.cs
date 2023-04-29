using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSkills", menuName = "PlayerSkills", order = 0)]
public class PlayerSkills : ScriptableObject
{
    // 0 = destruir
    // 1 = congelar
    // 2 = acelerar

    [System.Serializable]
    public class skillData
    {
        [Header("Damage and Area")]
        public float skillDamage;
        public float skillRadius;

        [Header("Time Related")]
        public float skillCooldown;
        public bool canCast;

        [Header("Ignora tudo abaixo")]
        public int skillIndex;
        public string skillName;

        [Header("Sound")]
        public AudioClip skillSound;
        
        [Header("Ignore")]
        public GameObject skillPrefab;
        public float skillCooldownTimer;
    }
    public skillData skillArray;

    public void CastSkill(Vector3 pos)
    {
        if(skillArray.canCast)
        {
            GameObject skill = Instantiate(skillArray.skillPrefab, pos, Quaternion.identity);
            ZeroCooldownTimer();    
        }
        
    }

    public void ZeroCooldownTimer()
    {
        skillArray.skillCooldownTimer = 0;
        skillArray.canCast = false;
    }

    public void Starting()
    {
        skillArray.canCast = true;
        skillArray.skillCooldownTimer = skillArray.skillCooldown;
    }
}
