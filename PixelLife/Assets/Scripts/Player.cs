using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed;
    public Sprite Forward;
    public Sprite Backward;
    public Sprite Left;
    public Sprite Right;

    public bool movementEnabled = true;
    private Animator animator;
    

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementEnabled)
        {
            int[] movementVals = HandleMovement();
            int moveHor = movementVals[0];
            int moveVer = movementVals[1];
            HandleAnimation(moveHor , moveVer);
        }
    }

    public void DisableMovement(string stopDirection)
    {
        movementEnabled = false;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (stopDirection == "Forward")
        {
            sr.sprite = Forward;
        }
        else if(stopDirection == "Backward")
        {
            sr.sprite = Backward;
        }
        else if(stopDirection == "Left")
        {
            sr.sprite = Left;
        }
        else if(stopDirection == "Right")
        {
            sr.sprite = Right;
        }

        animator.enabled = false;
    }
    public void EnableMovement()
    {
        animator.enabled = true;
        movementEnabled = true;
    }

    public void SimulateMovement(bool down , bool up , bool left , bool right)
    {
        SimulateWalking(down , up , left , right);
        HandleAnimation(0 , -1);
    }
    private void SimulateWalking(bool down , bool up , bool left , bool right)
    {
        int moveVer = 0;
        int moveHor = 0;
        if(down)
        {
            moveVer = -1;
        }
        if(up)
        {
            moveVer = 1;
        }
        if(left)
        {
            moveHor = -1;
        }
        if(right)
        {
            moveHor = 1;
        }


        Vector3 Movement = new Vector3(moveHor , moveVer , 0f);
        transform.position += Movement * Time.deltaTime * speed;
    }

    private int[] HandleMovement()
    {
        int moveVer = 0;
        int moveHor = 0;

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveVer = -1;
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveVer = 1;
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveHor = -1;
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveHor = 1;
        }

        Vector3 Movement = new Vector3(moveHor , moveVer , 0f);
        transform.position += Movement * Time.deltaTime * speed;
        return new int[] { moveHor , moveVer };
    }
    private void HandleAnimation(int horizontalMovement , int verticalMovement)
    {
        HandleIdles(horizontalMovement , verticalMovement);
        animator.SetInteger("Horizontal" , horizontalMovement);
        animator.SetInteger("Vertical" , verticalMovement);   
    }
    private void HandleIdles(int horizontalMovement, int verticalMovement)
    {
        bool isIdleState = animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        if (horizontalMovement == 0 && verticalMovement == 0)
        {
            animator.enabled = false;
        }
        else
        {
            if (!animator.enabled)
                animator.enabled = true;
        }
    }
}
