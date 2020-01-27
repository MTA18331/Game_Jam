using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 Movement;
    public Animator animator;
    public GameObject canvas;

    void Start()
    {
        Debug.Log(gameObject.transform.GetChild(0).gameObject.name);
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
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        canvas.gameObject.transform.gameObject.SetActive(true);

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("exit");
        {
            canvas.gameObject.transform.gameObject.SetActive(false);

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(Input.GetKeyDown("space"));
        Debug.Log("stay");
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("1 was pressed");
            canvas.gameObject.transform.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
                print("2 was pressed");
            canvas.gameObject.transform.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
                print("3 was pressed");
            canvas.gameObject.transform.gameObject.SetActive(false);
        }
    }
}

