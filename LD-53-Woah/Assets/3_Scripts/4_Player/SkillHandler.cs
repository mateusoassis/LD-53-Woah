using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHandler : MonoBehaviour
{
    public int selectedSkill;
    public PauseHandler pauseHandler;
    public bool mouseCanShoot;
    public AudioClipManager sound;

    [System.Serializable]
    public class SkillUI
    {
        public Image imageFillCooldown;
        public PlayerSkills skill;
        public GameObject mouse;

        [Header("Blink select skill")]
        public Image blinkIcon;
        public Color baseColor;
        public Color blinkColor;
        public float blinkInterval;
        public float blinkIntervalTimer;
        public bool blinkColorSwap;
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
        UpdateSelectedSkillIconColor();
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

    public void UpdateSelectedSkillIconColor()
    {
        for(int i = 0; i < skillUI.Length; i++)
        {
            if(i == selectedSkill)
            {
                if(!skillUI[i].blinkColorSwap)
                {
                    if(skillUI[i].blinkIntervalTimer <= skillUI[i].blinkInterval)
                    {
                        skillUI[i].blinkIntervalTimer += Time.deltaTime;
                    }
                    else
                    {
                        skillUI[i].blinkColorSwap = true;
                        skillUI[i].blinkIntervalTimer = 0f;
                    }

                    float perc = skillUI[i].blinkIntervalTimer / skillUI[i].blinkInterval;
                    //perc = 1f - Mathf.Cos(perc * Mathf.PI * 0.5f);
                    skillUI[i].blinkIcon.color = Color.Lerp(skillUI[i].blinkIcon.color, skillUI[i].blinkColor, perc = 1f - Mathf.Cos(perc * Mathf.PI * 0.5f));
                }
                else if(skillUI[i].blinkColorSwap)
                {
                    if(skillUI[i].blinkIntervalTimer <= skillUI[i].blinkInterval)
                    {
                        skillUI[i].blinkIntervalTimer += Time.deltaTime;
                    }
                    else
                    {
                        skillUI[i].blinkColorSwap = false;
                        skillUI[i].blinkIntervalTimer = 0f;
                    }

                    float perc = skillUI[i].blinkIntervalTimer / skillUI[i].blinkInterval;
                    //perc = 1f - Mathf.Cos(perc * Mathf.PI * 0.5f);
                    skillUI[i].blinkIcon.color = Color.Lerp(skillUI[i].blinkIcon.color, skillUI[i].baseColor, perc = 1f - Mathf.Cos(perc * Mathf.PI * 0.5f));
                }
            }
        }
    }

    public void DisableAllOtherColors()
    {
        for(int i = 0; i < skillUI.Length; i++)
        {
            if(i != selectedSkill)
            {
                skillUI[i].blinkColorSwap = false;
                skillUI[i].blinkIntervalTimer = 0f;
                skillUI[i].blinkIcon.color = skillUI[i].baseColor;
            }
        }
    }

    public void UpdateFillAmounts()
    {
        for(int i = 0; i < skillUI.Length; i++)
        {
            skillUI[i].imageFillCooldown.fillAmount = (skillUI[i].skill.skillArray.skillCooldown - skillUI[i].skill.skillArray.skillCooldownTimer) / skillUI[i].skill.skillArray.skillCooldown;
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
                    DisableAllOtherColors();
                }  
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                if(selectedSkill != 1)
                {
                    sound.PlayOneShot("SkillSwitch");
                    selectedSkill = 1;
                    SwapSkills(selectedSkill);
                    DisableAllOtherColors();
                }     
            }
            else if(Input.GetKeyDown(KeyCode.Alpha3))
            {
                if(selectedSkill != 2)
                {
                    sound.PlayOneShot("SkillSwitch");
                    selectedSkill = 2;
                    SwapSkills(selectedSkill);
                    DisableAllOtherColors();
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
