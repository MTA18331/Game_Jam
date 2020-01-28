using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchController : MonoBehaviour
{
    public int triggerID;

    private void Start()
    {
        GameEvents.gameEvents.onChurchCollide += onChurch;
    }

    private void onChurch(int id)
    {
        if (triggerID == id)
        {
            AudioManager.audioManager.PauseMusic(10.2f);
            AudioManager.audioManager.PlaySFXAsMusic(AudioManager.audioManager.sfxSounds[3], 10f);
        }
    }

    private void OnDestroy()
    {
        GameEvents.gameEvents.onChurchCollide -= onChurch;
    }
}
