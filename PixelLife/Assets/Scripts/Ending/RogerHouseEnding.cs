﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RogerHouseEnding : MonoBehaviour
{

    // Use this for initialization
    public GameObject Family;
    public GameObject Animation;
    public GameObject Woman;
    public GameObject PlayerSet;
    public GameObject Room;
    public Player _Player;
    public AudioSource EndMu;
    public AudioSource Appear;
    private float Timer = 0;
    private bool Kneel = false;
    private bool activation = false;
    public string scene;
    public HeadacheNoise Effect;

    void Start()
    {
        Family.SetActive(false);
        Animation.SetActive(false);
        Woman.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Kneel == true)
        {
            Timer += 1;

            if(Timer > 50)
            {
                PlayerSet.SetActive(false);
                Animation.SetActive(true);
                Room.GetComponent<Darkness>().enabled = true;
                Kneel = false;
                activation = true;
                EndMu.Play();
            }
        }
        if(activation == true)
        {
            Timer += 1;
            if(Timer > 1300)
            {
                SceneManager.LoadScene(scene);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _Player.movementEnabled = false;
            Kneel = true;
            // Missing the camera effect
            Family.SetActive(true);
            Woman.SetActive(true);

        }
    }

}
