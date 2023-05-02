using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "PlayerInfo", menuName = "PlayerInfo", order = 1)]
public class PlayerInfo : ScriptableObject
{
    [Range(0,1)]
    public float musicVolume;
    [Range(0,1)]
    public float sfxVolume;

    public bool seenTutorial;

    [Header("levels unlocked")]
    public int levelsUnlocked;

    public void AddLevelUnlocked()
    {
        levelsUnlocked++;
    }

}
