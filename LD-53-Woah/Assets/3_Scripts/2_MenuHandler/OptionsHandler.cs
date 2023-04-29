using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsHandler : MonoBehaviour
{
    [SerializeField] private GameObject optionsObject;

    public void OpenOptions()
    {
        optionsObject.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsObject.SetActive(false);
    }
}
