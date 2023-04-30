using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public Slider slider;

    public void ChangeMasterVolume()
    {
        playerInfo.masterVolume = slider.value;
    }
}
