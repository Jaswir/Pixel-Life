﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Texture2D HandCursorTexture2D;
    public Texture2D normalCursorTexture2D;

    void OnMouseDown()
    {
        //todo: act code
        Act act = GetComponent<Act>();
        act.PrepareAndOpenCurtains();
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(HandCursorTexture2D, Vector2.zero, CursorMode.Auto);
    }


    void OnMouseExit()
    {
        Cursor.SetCursor(normalCursorTexture2D, Vector2.zero, CursorMode.Auto);
    }
}

