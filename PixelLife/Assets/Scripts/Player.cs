﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public bool movementEnabled;

	// Update is called once per frame
	void Update ()
	{
	    if (movementEnabled)
	    {
	        float moveHor = Input.GetAxis("Horizontal");
	        float moveVer = Input.GetAxis("Vertical");
	        Vector3 Movement = new Vector3(moveHor, moveVer, 0f);
	        transform.position += Movement * Time.deltaTime * speed;
	    }
	}

}
