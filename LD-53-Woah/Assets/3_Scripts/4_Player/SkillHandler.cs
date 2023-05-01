using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHandler : MonoBehaviour
{
    [SerializeField] private int selectedSkill;
    [SerializeField] private PauseHandler pauseHandler;

    [System.Serializable]
    public class SkillUI
    {
        public Image image;
        public PlayerSkills skill;
    }
    public SkillUI[] skillUI;

    void Awake()
    {
        for(int i = 0; i < skillUI.Length; i++)
        {
            skillUI[i].skill.Starting();
        }
        pauseHandler = GameObject.Find("GameHandler").GetComponent<PauseHandler>();
    }

    void Update()
    {
        UpdateFillAmounts();
        Inputs(); 
        UpdateSkillCooldowns();
    }

    public void UpdateSkillCooldowns()
    {
        for(int i = 0; i < skillUI.Length; i++)
        {
            if(skillUI[i].skill.skillArray.skillCooldownTimer <= skillUI[i].skill.skillArray.skillCooldown)
            {
                skillUI[i].skill.skillArray.skillCooldownTimer += Time.deltaTime;
                // RefreshCooldown no controle da interface
            }
            else if(skillUI[i].skill.skillArray.skillCooldownTimer > skillUI[i].skill.skillArray.skillCooldown)
            {
                skillUI[i].skill.skillArray.canCast = true;
            }
        }
    }

    public void UpdateFillAmounts()
    {
        for(int i = 0; i < skillUI.Length; i++)
        {
            skillUI[i].image.fillAmount = (skillUI[i].skill.skillArray.skillCooldown - skillUI[i].skill.skillArray.skillCooldownTimer) / skillUI[i].skill.skillArray.skillCooldown;
        }
    }

    public void Inputs()
    {
        if(!pauseHandler.paused)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedSkill = 0;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedSkill = 1;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedSkill = 2;
            }

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                skillUI[selectedSkill].skill.CastSkill(mousePos);
            }
        }
    }
}
