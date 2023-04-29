using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] soundManager = GameObject.FindGameObjectsWithTag("Sound");
        if(soundManager.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
