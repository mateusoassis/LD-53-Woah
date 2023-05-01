using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateVolume : MonoBehaviour
{
    [SerializeField] private AudioClipManager sound;
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private Slider sliderSFX;
    [SerializeField] private Slider sliderMusic;

    void Awake()
    {
        sound = GetComponent<AudioClipManager>();
    }

    public void UpdateAllVolumes()
    {
        playerInfo.sfxVolume = sliderSFX.value;
        playerInfo.musicVolume = sliderMusic.value;
    }
}
