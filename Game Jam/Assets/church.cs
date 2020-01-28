using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
       
        //yield return new WaitForSeconds(5);
        cam4.gameObject.SetActive(true);
        cam3.gameObject.SetActive(true);
        cam1.gameObject.SetActive(false);
        cam2.gameObject.SetActive(false);
        cam4.gameObject.SetActive(true);
        P1UI.gameObject.SetActive(false);
        P2UI.gameObject.SetActive(false);
        yield return new WaitForSeconds(17);
        
        fader.SetActive(true);
        yield return new WaitForSeconds(2);
        buildend();
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void buildend()
    {
        Text wintext = Endcanvas.gameObject.transform.GetChild(1).GetComponent<Text>();
        Text p1 = Endcanvas.gameObject.transform.GetChild(2).GetComponent<Text>();
        Text p2 = Endcanvas.gameObject.transform.GetChild(3).GetComponent<Text>();
        p1.text = "Player 1: " + p1score.text;
        p2.text = "Player 2: " + p2score.text;


        int p1scoreint = int.Parse(p1score.text);
        int p2scoreint = int.Parse(p2score.text);
        if (p1scoreint > p2scoreint)
        {
            wintext.text = "Player 1 wins!";
        }
        else
        {
            wintext.text = "Player 2 wins!";
        }

     
        Endcanvas.SetActive(true);

    }
}
