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

    [SerializeField] private float transmissionTime;
    private float t = 0.0f; // Keeps track of time

    private void Start()
    {
        AudioManager.audioManager.firstMusicSourceIsPlaying = true;
        AudioManager.audioManager.PlayMusic(AudioManager.audioManager.ambientSounds[0]);
        AudioManager.audioManager.musicSource2.clip = AudioManager.audioManager.ambientSounds[1];
        t = Time.time;
    }

    private void Update()
    {

        if (Time.time-t >= AudioManager.audioManager.musicSource.clip.length - transmissionTime && AudioManager.audioManager.firstMusicSourceIsPlaying)
        {
            AudioManager.audioManager.PlayMusicWithCrossFade(AudioManager.audioManager.ambientSounds[1], transmissionTime);
            t = Time.time;
        } else if (Time.time - t >= AudioManager.audioManager.musicSource2.clip.length - transmissionTime)
        {
            AudioManager.audioManager.PlayMusicWithCrossFade(AudioManager.audioManager.ambientSounds[0], transmissionTime);
            t = Time.time;
        }
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioManager.audioManager.PlayMusicWithFade(AudioManager.audioManager.ambientSounds[1], transmissionTime);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioManager.audioManager.PlayMusicWithCrossFade(AudioManager.audioManager.ambientSounds[0], transmissionTime);
        }

    }

}
