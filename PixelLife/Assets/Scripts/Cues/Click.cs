﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Click : MonoBehaviour
{
    public Texture2D HandCursorTexture2D;
    public Texture2D normalCursorTexture2D;
    public string soundeffect_key;

    void OnMouseDown()
    {
        Event Event = GetComponent<Event>();
        Event.Run();

        SoundEffector.Instance.play(soundeffect_key);

        Cursor.SetCursor(normalCursorTexture2D, Vector2.zero, CursorMode.Auto);
        Destroy(this);
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

