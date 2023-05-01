using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private SkillHandler skill;

    void Awake()
    {
        skill = GameObject.Find("PlayerHandler").GetComponent<SkillHandler>();
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
       skill.mouseCanShoot = false;
       Debug.Log("dentro");
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        skill.mouseCanShoot = true;
        Debug.Log("fora");
    }
    
}
