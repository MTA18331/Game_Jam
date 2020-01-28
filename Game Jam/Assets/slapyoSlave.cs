using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slapyoSlave : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.ResetTrigger("Crouch");
            anim.SetTrigger("slap");
           // anim.ResetTrigger("slap");
        }
    }
}
