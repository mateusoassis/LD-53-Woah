using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [Header("Flags")]
    public bool paused;
    public bool dialogue;
    public bool playerLost;

    [Header("References")]
    [SerializeField] private GameObject pauseObject;
    void Update()
    {
        if(!dialogue)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(!paused)
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        paused = true;
        pauseObject.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        paused = false;
        pauseObject.SetActive(false);
    }
}