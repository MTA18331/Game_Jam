using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    public GameObject eat;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(eating());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startgame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator eating()
    {
        yield return new WaitForSeconds(3);
        eat.SetActive(false);
    }

}
