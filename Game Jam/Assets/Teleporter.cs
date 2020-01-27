using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        target.GetComponent<BoxCollider2D>().enabled = false;
        collision.transform.position = target.transform.position;
        StartCoroutine(fixTeleport());
    }

    IEnumerator fixTeleport()
    {
        yield return new WaitForSeconds(5);
        GetComponent<BoxCollider2D>().enabled = true;
        target.GetComponent<BoxCollider2D>().enabled = true;
    }
}
   
