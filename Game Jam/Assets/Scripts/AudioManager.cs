using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region AudioManager instance
    private static AudioManager instance;
    public static AudioManager audioManager
    {
        get
        {
            return instance;
        }

        private set
        {
            if (instance != null)
            {
                Destroy(value.gameObject);
                return;
            }
            instance = value;
        }
    }
    #endregion

    #region AudioSources
    [HideInInspector] public AudioSource musicSource;
    [HideInInspector] public AudioSource musicSource2;
    [HideInInspector] public AudioSource sfxSource;
    #endregion
    
    #region Ambient audio clips
    [Header("Ambient sounds Audio Clips")]
    public AudioClip[] ambientSounds;
    #endregion

    #region SFX audio clips
    [Header("SFX Audio Clips")]
    public AudioClip[] sfxSounds;
    #endregion

    [HideInInspector] public bool firstMusicSourceIsPlaying;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource2 = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

    }

    public void PlayMusic(AudioClip musicClip)
    {
        // Determine which sourcer is active
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;

        musicSource.clip = musicClip;
        activeSource.volume = 1;
        musicSource.Play();

    }

    public void PlayMusicWithFade(AudioClip newClip, float transitionTime = 1.0f)
    {
        // Determine which source is active
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;
        StartCoroutine(UpdateMusicWithFade(activeSource, newClip, transitionTime));
    }

    public void PlayMusicWithCrossFade(AudioClip musicClip, float transitionTime = 1.0f)
    {
        // Determine which source is active
        AudioSource activeSource = (firstMusicSourceIsPlaying) ? musicSource : musicSource2;
        AudioSource newSource = (firstMusicSourceIsPlaying) ? musicSource2 : musicSource;

        // Swap the source 
        firstMusicSourceIsPlaying = !firstMusicSourceIsPlaying;

        // Set the fields of the audio source, then start the coroutine to crossfade
        newSource.clip = musicClip;
        newSource.Play();
        StartCoroutine(UpdateMusicWithCrossFade(activeSource, newSource, transitionTime));
    }

    public void PauseMusic(float waitTime)
    {
        AudioSource activeSource = musicSource.isPlaying ? musicSource : musicSource2;

        activeSource.Pause();
        StartCoroutine(PauseMusic(activeSource, waitTime));
         
    }

    #region PlaySFX Methods
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        sfxSource.PlayOneShot(clip, volume);
    }
    #endregion

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        musicSource2.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    // Method: fades out the current audio clip and fades in a new. 
    private IEnumerator UpdateMusicWithFade(AudioSource acitveSource, AudioClip newClip, float transitionTime)
    {
        // Make sure the source is active and playing 
        if (!acitveSource.isPlaying)
        {
            acitveSource.Play();
        }

        // Fade Out
        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            acitveSource.volume = (1 - (t / Time.deltaTime)); // Lower the volume of the active source for each second.
            yield return null;
        }

        // Stop the current clip, assign the current clip to the new clip and play it. 
        acitveSource.Stop();
        acitveSource.clip = newClip;
        acitveSource.Play();

        // Fade In
        for (float t = 0; t < transitionTime; t += Time.deltaTime)
        {
            acitveSource.volume = (t / Time.deltaTime); // increase the volume of the active source for each second.
            yield return null;
        }
    }

    // Fades out current source and fades in new source simultaneously.
    private IEnumerator UpdateMusicWithCrossFade(AudioSource original, AudioSource newSource, float transitionTime)
    {

        for (float t = 0.0f; t <= transitionTime; t += Time.deltaTime)
        {
            original.volume = (1 - (t / Time.deltaTime)); // Fades out the current source by lowering the volume.
            newSource.volume = (t / Time.deltaTime); // Fades in the new source by increasing the volume.
            yield return null;
        }

        original.Stop();

    }

    private IEnumerator PauseMusic(AudioSource activeSource, float waitTime = 1.0f)
    {
        yield return new WaitForSeconds(waitTime);
        activeSource.UnPause();
    }


}
