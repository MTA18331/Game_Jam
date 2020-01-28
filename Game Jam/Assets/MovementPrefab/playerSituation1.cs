using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSituation1 : MonoBehaviour
{
    public string sitName;
    public string option1;
    public string option2;
    public string option3;
    public int option1points;
    public int option2points;
    public int option3points;
    GameObject birds;
    void Start()
    {
        birds = Resources.Load("MovementPrefab/confusedbirds") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        Instantiate(birds, pos, birds.transform.rotation);
    }
}
