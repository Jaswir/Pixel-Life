using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingRoger : MonoBehaviour {

    public float speed;
    public bool movementEnabled;
    private float TimerToNExt;
    private Renderer RogerPic;
    private Animator animator;
    public GameObject Body;
    public AudioSource Tape1;
    public AudioSource Tape2;
    private bool TheEnd=false;
    void Start()
    {
        animator = GetComponent<Animator>();
        TimerToNExt = 0;
        RogerPic= GetComponent<SpriteRenderer>();
        Body.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TimerToNExt += 1 * Time.deltaTime;
        Debug.Log(TimerToNExt);
        if (movementEnabled)
        {
            int moveVer = HandleMovement();
            HandleAnimation(moveVer);
        }
        //if (Input.anyKey)
       // {
       //     TimerToNExt +=1;
       // }
    }

    private int HandleMovement()
    {
        int moveVer = 0;
        int moveHor = 0;
        //if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //{
        //    moveVer = -1;
        // }
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        // {
        //     moveVer = 1;
        // }
        // if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        // {
        //     moveHor = -1;
        // }
        // if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        // {
        //     moveHor = 1;
        // }
        if (TimerToNExt>3 && TimerToNExt<3.5)
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
        if(TimerToNExt>35.7 && TimerToNExt <40)
        {
            RogerPic.enabled = false;
            Body.SetActive(true);
            Tape1.volume = 0.8f;
        }

        if (TimerToNExt > 57 && TimerToNExt < 61)
        {
            Tape1.volume = 0.5f;
        }
       
        if (TimerToNExt > 62)
        {   
            if(TheEnd == false) { 
            Tape1.Stop();
            Tape2.Play();
            TheEnd = true;
            }
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
