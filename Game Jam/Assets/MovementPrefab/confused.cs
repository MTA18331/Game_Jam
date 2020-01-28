using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confused : MonoBehaviour
{
  
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        StartCoroutine(confused2());
    }

    IEnumerator confused2()
    {
        PlayerMovement player = GetComponentInParent<PlayerMovement>();
      
        player.confused = true;

        AudioManager.audioManager.PlaySFX(AudioManager.audioManager.sfxSounds[0]);
        yield return new WaitForSeconds(3);
        player.confused = false;
       
        gameObject.SetActive(false);
    }


}
