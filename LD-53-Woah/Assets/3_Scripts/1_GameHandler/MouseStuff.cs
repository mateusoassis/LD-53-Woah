using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStuff : MonoBehaviour
{
    [SerializeField] private SkillHandler skill;
    [SerializeField] private GameObject[] mouses;

    void Start()
    {
        skill = GameObject.Find("PlayerHandler").GetComponent<SkillHandler>();
    }
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
