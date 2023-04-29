using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "PlayerInfo", menuName = "PlayerInfo", order = 1)]
public class PlayerInfo : ScriptableObject
{
    public int checkpointReached;
    public bool loadSound;
    public bool noIntroduction;

    public void NewGame()
    {
        checkpointReached = 0;
        loadSound = true;
    }
    public void ContinueGame()
    {
        loadSound = true;
    }
    public void DisableIntroductionAfterThis()
    {
        noIntroduction = true;
    }
}
