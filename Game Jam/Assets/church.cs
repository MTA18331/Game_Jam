using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class church : MonoBehaviour
{
    public  GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject cam4;
    public GameObject P1UI;
    public GameObject P2UI;
    public GameObject fader;
    public GameObject Endcanvas;
    public Text p1score;
    public Text p2score;
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
       
       // yield return new WaitForSeconds(5);
        cam4.gameObject.SetActive(true);
        cam3.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam4.gameObject.SetActive(true);
        P1UI.gameObject.SetActive(false);
        P2UI.gameObject.SetActive(false);
        AudioManager.audioManager.PauseMusic(AudioManager.audioManager.sfxSounds[1].length + 0.5f);
        AudioManager.audioManager.PlaySFX(AudioManager.audioManager.sfxSounds[1]);


       
        yield return new WaitForSeconds(17);
        fader.SetActive(true);
        yield return new WaitForSeconds(3);
        buildend();
    }

    void buildend()
    {
        Text wintext = Endcanvas.gameObject.transform.GetChild(1).GetComponent<Text>();
        Text p1 = Endcanvas.gameObject.transform.GetChild(2).GetComponent<Text>();
        Text p2 = Endcanvas.gameObject.transform.GetChild(3).GetComponent<Text>();
        Debug.Log(p1score.text);
        Debug.Log(p2score.text);
       

        int p1scoreint = int.Parse(p1score.text);
        int p2scoreint = int.Parse(p2score.text);

        p1.text = "Player 1: " + p1scoreint.ToString();
        p2.text = "Player 2: " + p1scoreint.ToString();

        if (p1scoreint > p2scoreint)
        {
            wintext.text = "Player 1 wins!";
        }
        else if(p1scoreint < p2scoreint)
        {
            wintext.text = "Player 2 wins!";
        } else
        {
            wintext.text = "No one won! :(";
        }


        Endcanvas.SetActive(true);



    }
    public void playAgain ()
    {

    }
}
