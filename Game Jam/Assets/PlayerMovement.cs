﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
     Rigidbody2D rb;
    Vector2 Movement;
     Animator animator;
    public GameObject interactText;
    public int points;
    public GameObject score;
     situation CurrentSit;
    Text option1;
    Text option2;
    Text option3;
    Text scoretext;
    Image[] scoremeter = new Image[6];
    Boolean canInteract = false;
    public KeyCode one;
    public KeyCode two;
    public KeyCode three;
   
    public String axisUp;
    public String axisSides;
    public Boolean confused = false;
    void Start()
    {

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scoretext = score.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
       
        int k = 0;
        for (int i = 2; i < score.gameObject.transform.childCount; i++)
        {
            
            scoremeter[k] = score.gameObject.transform.GetChild(i).gameObject.GetComponent<Image>();
            k++;
        }
    
    }

    private void Update()
    {
        if (confused)
        {
            return;
        }

        Movement.x = Input.GetAxisRaw(axisSides);
        Movement.y = Input.GetAxisRaw(axisUp);

        if (animator != null)
        {
            animator.SetFloat("Horizontal", Movement.x);
            animator.SetFloat("Vertical", Movement.y);
            animator.SetFloat("Speed", Movement.sqrMagnitude);
        }

        UpdateScores();

        if (canInteract)
        {
            if (Input.GetKeyDown(one))
            {
                interactText.gameObject.transform.gameObject.SetActive(false);
                points += CurrentSit.option1points;
                canInteract = false;
                Text flyingText = score.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                flyingText.text = CurrentSit.option1points.ToString();
                flyingText.gameObject.SetActive(true);

                if(CurrentSit.gameObject.tag == "player" && option1.text == "hit")
                {
                    CurrentSit.playerHit();
                } else if(CurrentSit.gameObject.tag == "player"){
                    GetComponent<situation>().playerHit();
                }

            }
            if (Input.GetKeyDown(two))
            {

                interactText.gameObject.transform.gameObject.SetActive(false);
                points += CurrentSit.option2points;
                canInteract = false;
                Text flyingText = score.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                flyingText.text = CurrentSit.option2points.ToString();
                flyingText.gameObject.SetActive(true);

                if (CurrentSit.gameObject.tag == "player" && option1.text == "hit")
                {
                    CurrentSit.playerHit();
                }
                else if (CurrentSit.gameObject.tag == "player")
                {
                    GetComponent<situation>().playerHit();
                }
            }
            if (Input.GetKeyDown(three))
            {

                interactText.gameObject.transform.gameObject.SetActive(false);
                points += CurrentSit.option3points;
                canInteract = false;
                Text flyingText = score.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
                flyingText.text = CurrentSit.option3points.ToString();
                flyingText.gameObject.SetActive(true);

                if (CurrentSit.gameObject.tag == "player" && option1.text == "hit")
                {
                    CurrentSit.playerHit();
                }
                else if (CurrentSit.gameObject.tag == "player")
                {
                    GetComponent<situation>().playerHit();
                }

            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.tag != "situation" && collision.gameObject.tag != "player")
        {
            return;
        }

        if (collision.gameObject.tag == "player")
        {
            CurrentSit = collision.gameObject.GetComponent<situation>();
            playersit();
            
        }

        else if ( CurrentSit != collision.gameObject.GetComponent<situation>())
        {
            CurrentSit = collision.gameObject.GetComponent<situation>();
          
            sortOutSit();
        }

        interactText.gameObject.transform.gameObject.SetActive(true);
        canInteract = true; 

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        {

            interactText.gameObject.transform.gameObject.SetActive(false);
            canInteract = false;

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
     
   
        
    }

    void playersit()
    {
        int r1 = UnityEngine.Random.Range(1, 4);
        int r2 = UnityEngine.Random.Range(1, 4);
        while (r2 == r1)
        {
            r2 = UnityEngine.Random.Range(1, 4);
        }
        int r3 = UnityEngine.Random.Range(1, 4);
        while (r3 == r1 || r3 == r2)
        {
            r3 = UnityEngine.Random.Range(1, 4);
        }
        

        option1 = interactText.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        option2 = interactText.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        option3 = interactText.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>();
        option1.text = randomize(r1);

        option2.text = randomize(r2);

        option3.text = randomize(r3);
       
    }

    String randomize(int i)
    {
        switch (i)
        {
            default:
                return "Error";
          
            case 1:
                return "hit";
           
            case 2:
                return "Fall";
             
            case 3:
                return "Honk";
               

        }
    }

    void sortOutSit()
    {

        option1 = interactText.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        option2 = interactText.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        option3 = interactText.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>();

        option1.text = CurrentSit.option1;

        option2.text = CurrentSit.option2;

        option3.text = CurrentSit.option3;
    }

    void UpdateScores()
    {
         
        scoretext.text= points.ToString();

        if (points > 0)
        {
          scoremeter[0].color = Color.red;
            
        }
        if (points > 200)
        {
            scoremeter[1].color = Color.red;

        }
        if (points > 400)
        {
            scoremeter[2].color = Color.red;

        }
        if (points > 600)
        {
            scoremeter[3].color = Color.red;

        }
        if (points > 800)
        {
            scoremeter[4].color = Color.red;

        }
        if (points > 1000)
        {
            scoremeter[5].color = Color.red;

        }
    }


}

