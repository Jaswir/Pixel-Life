﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unveil : MonoBehaviour
{
    public SpriteRenderer noDoorSpriteRenderer;
    public Sprite withDoor;
    public string soundeffect_key;

    // Update is called once per frame
    void Update()
    {
            if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) ||
                Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.D))
            {

                noDoorSpriteRenderer.sprite = withDoor;
                SoundEffector.Instance.play(soundeffect_key);
                Destroy(this);
            }
    }


}
