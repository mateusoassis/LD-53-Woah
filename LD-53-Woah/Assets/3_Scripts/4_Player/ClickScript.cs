using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    [Header("Flags")]
    public bool canClick;

    [Header("Player Stats")]
    [SerializeField] private float clickDamage;
}
