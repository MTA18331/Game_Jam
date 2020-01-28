using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class situation : MonoBehaviour
{
    public string sitName;
    public string option1;
    public string option2;
    public string option3;
    public int option1points;
    public int option2points;
    public int option3points;
    public GameObject birds;
    void Start()
    {

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerHit()
    {
        Debug.Log("happened");
        
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        birds.transform.position = pos;
        birds.transform.SetParent(this.gameObject.transform);
        birds.SetActive(true);

    }
}
