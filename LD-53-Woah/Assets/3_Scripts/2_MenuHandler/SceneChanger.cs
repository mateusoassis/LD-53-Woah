using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [Header("Scenes Info")]
    [SerializeField] private int currentIndex;
    [SerializeField] private string introName;
    [SerializeField] private string menuName;
    [SerializeField] private string gameTutorialStartName;
    [SerializeField] private string nextScene;
    [SerializeField] private PlayerInfo playerInfo;
    [SerializeField] private int subtract;

    // 0 = intro
    // 1 = menu
    // 2 = tutorial game
    
    void Awake()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentIndex > 1)
        {
            if(playerInfo.levelsUnlocked < currentIndex - subtract)
            {
                playerInfo.levelsUnlocked = currentIndex - subtract;
            }    
        }
        
    }

    public void SwapToMenu()
    {
        SceneManager.LoadScene(menuName);
    }

    public void SwapToGame()
    {
        SceneManager.LoadScene(gameTutorialStartName);
    }
    public void SwapToNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
