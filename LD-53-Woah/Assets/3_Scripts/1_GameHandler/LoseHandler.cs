using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHandler : MonoBehaviour
{
    [SerializeField] private PlayerStatus playerStatus;
    [SerializeField] private GameObject loseObject;
    [SerializeField] private PauseHandler pauseHandler;

    void Awake()
    {
        playerStatus = GameObject.Find("DestinationPoint").GetComponent<PlayerStatus>();
        pauseHandler = GetComponent<PauseHandler>();
    }

    public void DidPlayerLost()
    {
        if(playerStatus.currentHealth <= 0)
        {
            Time.timeScale = 0;
            pauseHandler.paused = true;
            pauseHandler.playerLost = true;  
            loseObject.SetActive(true);
            playerStatus.cameraShake.StopShake();  
        }
    }
}
