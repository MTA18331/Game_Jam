using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class church : MonoBehaviour
{
    public  GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject P1UI;
    public GameObject P2UI;
    // Start is called before the first frame update

    void Start()
    {
       
    }
    void OnEnable()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(churchScene());
    }

    IEnumerator churchScene()
    {
       
        yield return new WaitForSeconds(5);
        cam4.gameObject.SetActive(true);
        cam3.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam4.gameObject.SetActive(true);
        P1UI.gameObject.SetActive(false);
        P2UI.gameObject.SetActive(false);
        AudioManager.audioManager.PauseMusic(AudioManager.audioManager.sfxSounds[1].length + 0.5f);
        AudioManager.audioManager.PlaySFX(AudioManager.audioManager.sfxSounds[1]);
    }
}
