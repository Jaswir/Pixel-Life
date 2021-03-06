﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingRoger : MonoBehaviour
{
    public float speed;
    public bool movementEnabled;
    private float TimerToNExt;
    private Renderer RogerPic;
    private Animator animator;
    public GameObject Body;
    public AudioSource Tape1;
    public AudioSource Tape2;
    private bool TheEnd = false;
    public float tapeSwitchTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        TimerToNExt = 0;
        RogerPic = GetComponent<SpriteRenderer>();
        Body.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimerToNExt += 1 * Time.deltaTime;
        if (movementEnabled)
        {
            int[] movementVals = HandleMovement();
            int moveHor = movementVals[0];
            int moveVer = movementVals[1];
            HandleAnimation(moveHor , moveVer);
        }
    }

    private int[] HandleMovement()
    {
        int moveVer = 0;
        int moveHor = 0;

        if (TimerToNExt > 3 && TimerToNExt < 3.5)
        {
            moveVer = -1;
        }
        if (TimerToNExt > 8 && TimerToNExt < 8.5)
        {
            moveVer = -1;
        }
        if (TimerToNExt > 10 && TimerToNExt < 11.3)
        {
            moveVer = -1;
        }
        if (TimerToNExt > 20 && TimerToNExt < 21)
        {
            moveVer = 1;
        }
        if (TimerToNExt > 25 && TimerToNExt < 26)
        {
            moveVer = -1;
        }
        if (TimerToNExt > 35 && TimerToNExt < 35.7)
        {
            moveVer = -1;
            speed = 20;
        }
        if (TimerToNExt > 35.7 && TimerToNExt < 40)
        {
            RogerPic.enabled = false;
            Body.SetActive(true);
            Tape1.volume = 0.8f;
        }

        if (TimerToNExt > 57 && TimerToNExt < 61)
        {
            Tape1.volume = 0.5f;
        }

        if (TimerToNExt > tapeSwitchTime)
        {
            if (TheEnd == false)
            {
                Tape1.Stop();
                Tape2.Play();
                TheEnd = true;
            }
        }
        Vector3 Movement = new Vector3(moveHor, moveVer, 0f);
        transform.position += Movement * Time.deltaTime * speed;

        return new int[] {moveHor, moveVer};
    }

    private void HandleAnimation(int horizontalMovement , int verticalMovement)
    {
        HandleIdles(horizontalMovement , verticalMovement);
        animator.SetInteger("Horizontal" , horizontalMovement);
        animator.SetInteger("Vertical" , verticalMovement);
    }

    private void HandleIdles(int horizontalMovement , int verticalMovement)
    {
        bool isIdleState = animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        if(horizontalMovement == 0 && verticalMovement == 0)
        {
            animator.enabled = false;
        }
        else
        {
            if(!animator.enabled)
                animator.enabled = true;
        }
    }
}
