using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region GameManager instance
    private static GameManager instane;

    public static GameManager gameManager
    {
        get
        {
            return instane;
        }

        set
        {
            if (instane != null)
            {
                instane = value;
            }
        }
    }
    #endregion

    private void Awake()
    {
        gameManager = this;
    }

    private void Start()
    {
        AudioManager.audioManager.musicSource = AudioManager.audioManager.GetComponent<AudioSource>();
        AudioManager.audioManager.musicSource2 = AudioManager.audioManager.GetComponent<AudioSource>();
        AudioManager.audioManager.sfxSource = AudioManager.audioManager.GetComponent<AudioSource>();
        AudioManager.audioManager.firstMusicSourceIsPlaying = true;
        //AudioManager.audioManager.musicSource.clip = AudioManager.audioManager.ambientSounds[0];
        AudioManager.audioManager.PlayMusic(AudioManager.audioManager.ambientSounds[Random.Range(0, AudioManager.audioManager.ambientSounds.Length)]);
    }

    private void Update()
    {

        if (AudioManager.audioManager.musicSource.clip.length < 5)
        {
            //AudioManager.audioManager.PlayMusicWithFade(AudioManager.audioManager.);
        }

    }

}
