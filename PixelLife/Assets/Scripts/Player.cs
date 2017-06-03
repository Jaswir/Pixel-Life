using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public float speed;
    private bool movementEnabled = true;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (movementEnabled)
        {
            int moveVer = HandleMovement();
            HandleAnimation(moveVer);
        }
    }

    public void DisableMovement()
    {
        movementEnabled = false;
        animator.SetInteger("State", 0);
    }

    public void EnableMovement()
    {
        movementEnabled = true;
    }

   
    public void SimulateMovement(bool down, bool up, bool left, bool right)
    {
        int moveVer = SimulateWalking(down, up, left, right);
        HandleAnimation(moveVer);
    }
    private int SimulateWalking(bool down, bool up, bool left, bool right)
    {
        int moveVer = 0;
        int moveHor = 0;
        if (down)
        {
            moveVer = -1;
        }
        if (up)
        {
            moveVer = 1;
        }
        if (left)
        {
            moveHor = -1;
        }
        if (right)
        {
            moveHor = 1;
        }


        Vector3 Movement = new Vector3(moveHor, moveVer, 0f);
        transform.position += Movement * Time.deltaTime * speed;
        return moveVer;
    }

    private int HandleMovement()
    {
        int moveVer = 0;
        int moveHor = 0;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            moveVer = -1;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            moveVer = 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveHor = -1;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveHor = 1;
        }


        Vector3 Movement = new Vector3(moveHor, moveVer, 0f);
        transform.position += Movement * Time.deltaTime * speed;

        return moveVer;
    }
    private void HandleAnimation(int verticalMovement)
    {
        if (verticalMovement == 1)
        {
            animator.SetInteger("State", 1);
        }
        else if (verticalMovement == -1)
        {
            animator.SetInteger("State", -1);
        }
        else
        {
            animator.SetInteger("State", 0);
        }
    }
}
