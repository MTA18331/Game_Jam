using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 Movement;
    public Animator animator;
    public GameObject canvas;
    public int points;
    public GameObject score;
    situation CurrentSit;

    void Start()
    {
        score = gameObject.transform.GetChild(1).GetChild(0).gameObject;
        canvas = gameObject.transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody2D>();
        try
        {
            animator = GetComponent<Animator>();
        }
        catch (Exception e)
        {
            print("no animator yet");
        }
    }

    private void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        if (animator != null)
        {
            animator.SetFloat("Horizontal", Movement.x);
            animator.SetFloat("Vertical", Movement.y);
            animator.SetFloat("Speed", Movement.sqrMagnitude);
        }

        UpdateScores();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // get situation script from collision
        // based on situation set options for what to do in situation 
        CurrentSit = collision.gameObject.GetComponent<situation>();
        canvas.gameObject.transform.gameObject.SetActive(true);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        {
            
            canvas.gameObject.transform.gameObject.SetActive(false);

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Text tx1 = canvas.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        tx1.text = CurrentSit.option1;
        Text tx2 = canvas.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        tx2.text = CurrentSit.option2;
        Text tx3 = canvas.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>();
        tx3.text = CurrentSit.option2;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            {
            canvas.gameObject.transform.gameObject.SetActive(false);
            points += CurrentSit.option1points;
            }
       if (Input.GetKeyDown(KeyCode.Alpha2))
            {
          
            canvas.gameObject.transform.gameObject.SetActive(false);
            points += CurrentSit.option2points;
        }
       if (Input.GetKeyDown(KeyCode.Alpha3))
            {
          
            canvas.gameObject.transform.gameObject.SetActive(false);
            points += CurrentSit.option3points;

        }
        
    }

    void UpdateScores()
    {
        Text tx = score.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        tx.text= points + " points";

        if (points > 0)
        {
           Image im = score.gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
            im.color = Color.red;
            
        }
        if (points > 200)
        {
            Image im = score.gameObject.transform.GetChild(2).gameObject.GetComponent<Image>();
            im.color = Color.red;

        }
        if (points > 400)
        {
            Image im = score.gameObject.transform.GetChild(3).gameObject.GetComponent<Image>();
            im.color = Color.red;

        }
        if (points > 600)
        {
            Image im = score.gameObject.transform.GetChild(4).gameObject.GetComponent<Image>();
            im.color = Color.red;

        }
        if (points > 800)
        {
            Image im = score.gameObject.transform.GetChild(5).gameObject.GetComponent<Image>();
            im.color = Color.red;

        }
        if (points > 1000)
        {
            Image im = score.gameObject.transform.GetChild(6).gameObject.GetComponent<Image>();
            im.color = Color.red;

        }
    }


}

