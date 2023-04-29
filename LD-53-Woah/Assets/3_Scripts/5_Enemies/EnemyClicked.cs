using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClicked : MonoBehaviour
{
    private ClickScript clickHandler;

    void Awake()
    {
        clickHandler = GameObject.Find("ClickHandler").GetComponent<ClickScript>();
    }
    void OnMouseDown()
    {
        GetComponent<EnemyBehaviour>().EnemyTakeDamage(clickHandler.clickDamage);
    }
}
