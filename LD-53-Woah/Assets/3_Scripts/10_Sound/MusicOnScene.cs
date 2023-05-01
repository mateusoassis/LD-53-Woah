using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicOnScene : MonoBehaviour
{
    public AudioClipManager sound;

    public string menuSceneName;
    public string hardGameSceneName;

    public bool menuMusic;
    public bool gameMusic;
    public bool hardGameMusic;

    void Awake()
    {
        sound = GameObject.Find("SoundManager").GetComponent<AudioClipManager>();
    }

    void Start()
    {
        ChangeMusic();
    }

    public void ChangeMusic()
    {
        if(SceneManager.GetActiveScene().name == menuSceneName)
        {
            if(!menuMusic)
            {
                sound.Play("MainMenu");
                sound.StopSound("BlueSong");
                sound.StopSound("MinorHarmonicSong");
                menuMusic = true;
                gameMusic = false;
                hardGameMusic = false;
            }
        }
        else if(SceneManager.GetActiveScene().name == hardGameSceneName)
        {
            if(!hardGameMusic)
            {
                sound.StopSound("MainMenu");
                sound.StopSound("BlueSong");
                sound.Play("MinorHarmonicSong");
                menuMusic = false;
                gameMusic = false;
                hardGameMusic = true;
            }
        }
        else if(SceneManager.GetActiveScene().name != menuSceneName && SceneManager.GetActiveScene().name != hardGameSceneName)
        {
            if(!gameMusic)
            {
                sound.StopSound("MainMenu");
                sound.Play("BlueSong");
                sound.StopSound("MinorHarmonicSong");
                menuMusic = false;
                gameMusic = true;
                hardGameMusic = false;
            }
        }
    }
}
