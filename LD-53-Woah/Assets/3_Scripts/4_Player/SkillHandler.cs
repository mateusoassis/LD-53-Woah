using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHandler : MonoBehaviour
{
    public int selectedSkill;
    [SerializeField] private PauseHandler pauseHandler;
    public bool mouseCanShoot;
    public AudioClipManager sound;

    [System.Serializable]
    public class SkillUI
    {
        public Image image;
        public PlayerSkills skill;
        public GameObject mouse;
    }
    public SkillUI[] skillUI;

    void Awake()
    {
        for(int i = 0; i < skillUI.Length; i++)
        {
            skillUI[i].skill.Starting();
        }
        pauseHandler = GameObject.Find("GameHandler").GetComponent<PauseHandler>();
        sound = GameObject.Find("SoundManager").GetComponent<AudioClipManager>();
    }

    void Start()
    {
        mouseCanShoot = true;
        SwapSkills(selectedSkill);
        Cursor.visible = false;
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
                if(selectedSkill != 0)
                {
                    sound.PlayOneShot("SkillSwitch");
                    selectedSkill = 0;
                    SwapSkills(selectedSkill);
                }  
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                if(selectedSkill != 1)
                {
                    sound.PlayOneShot("SkillSwitch");
                    selectedSkill = 1;
                    SwapSkills(selectedSkill);
                }     
            }
            else if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                if(selectedSkill != 2)
                {
                    sound.PlayOneShot("SkillSwitch");
                    selectedSkill = 2;
                    SwapSkills(selectedSkill);
                }                
            }

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                if(mouseCanShoot)
                {
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePos.z = 0;
                    skillUI[selectedSkill].skill.CastSkill(mousePos);
                }
            }
        }
    }

    
    public void SwapSkills(int a)
    {
        for (int i = 0; i < skillUI.Length; i++)
        {
            if(i == a)
            {
                skillUI[i].mouse.SetActive(true);
            }
            else
            {
                skillUI[i].mouse.SetActive(false);
            }
        }
        Cursor.visible = false;
    }
    public void ShowMouseCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        for (int i = 0; i < skillUI.Length; i++)
        {
            {
                skillUI[i].mouse.SetActive(false);
            }
        }
        Cursor.visible = true;
    }
    
}
