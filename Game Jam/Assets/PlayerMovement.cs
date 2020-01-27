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
    Text option1;
    Text option2;
    Text option3;
    Text scoretext;
    Image[] scoremeter = new Image[6];
    Boolean canInteract = false;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode rigth;
    public String axisUp;
    public String axisSides;
    void Start()
    {
        score = gameObject.transform.GetChild(1).GetChild(0).gameObject;
        canvas = gameObject.transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody2D>();
        scoretext = score.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        try
        {
            animator = GetComponent<Animator>();
        }
        catch (Exception e)
        {
            print("no animator yet");
        }

        for (int i = 0; i < score.gameObject.transform.childCount-1; i++)
        {
            
            scoremeter[i] = score.gameObject.transform.GetChild(i+1).gameObject.GetComponent<Image>();
        }
    
    }

    private void Update()
    {
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
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                canvas.gameObject.transform.gameObject.SetActive(false);
                points += CurrentSit.option1points;
                canInteract = false;
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                canvas.gameObject.transform.gameObject.SetActive(false);
                points += CurrentSit.option2points;
                canInteract = false;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {

                canvas.gameObject.transform.gameObject.SetActive(false);
                points += CurrentSit.option3points;
                canInteract = false;

            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "situation")
        {
            return;
        }

        if (CurrentSit == null || CurrentSit != collision.gameObject.GetComponent<situation>())
        {
            CurrentSit = collision.gameObject.GetComponent<situation>();
            sortOutSit();
        }
      
       canvas.gameObject.transform.gameObject.SetActive(true);
        canInteract = true; 

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        {
            
            canvas.gameObject.transform.gameObject.SetActive(false);
            canInteract = false;

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
     
   
        
    }

    void sortOutSit()
    {
        option1 = canvas.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        option2 = canvas.gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
        option3 = canvas.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>();

        option1.text = CurrentSit.option1;

        option2.text = CurrentSit.option2;

        option3.text = CurrentSit.option3;
    }

    void UpdateScores()
    {
         
        scoretext.text= points + " points";

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

