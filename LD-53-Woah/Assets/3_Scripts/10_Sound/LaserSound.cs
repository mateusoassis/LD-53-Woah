using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSound : MonoBehaviour
{
    void Awake()
    {
        GameObject.Find("SoundManager").GetComponent<AudioClipManager>().PlayOneShot("LaserSound");
    }
}
