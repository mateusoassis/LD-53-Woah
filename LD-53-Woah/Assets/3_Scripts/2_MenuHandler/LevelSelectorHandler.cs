using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorHandler : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectorObject;
    [SerializeField] private string[] levelNames;

    public void ChangeToLevel(int a)
    {
        SceneManager.LoadScene(levelNames[a]);
    }

    public void OpenLevelSelector()
    {
        levelSelectorObject.SetActive(true);
    }
    public void CloseLevelSelector()
    {
        levelSelectorObject.SetActive(false);
    }
}
