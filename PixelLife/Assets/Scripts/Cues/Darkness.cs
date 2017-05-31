using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkness : MonoBehaviour
{

    public float fadeoutTime;
    public float fadeoutStartTime;
    public string narration_key;

    private SpriteRenderer spriteRenderer;
    private float fadeoutTimer;
    private float startTimer;
    private bool narrated;

    public bool hasResult;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Fade()
    {
        fadeoutTimer += Time.deltaTime / fadeoutTime;

        Color curColor = spriteRenderer.color;
        curColor.a = Mathf.Lerp(1.0f, 0.0f, fadeoutTimer);
        spriteRenderer.color = curColor;

        if (fadeoutTimer >= fadeoutTime)
        { 
            ExecuteResults();
        }
    }


    private void ExecuteResults()
    {
        if (hasResult)
        {
            Result result = GetComponent<Result>();
            result.Execute();
        }
    }

    void Update()
    {
        startTimer += Time.deltaTime;
        if (startTimer >= fadeoutStartTime)
        {
            if (!narrated)
            {
                Narrator.Instance.narrate(narration_key);
                narrated = true;
            }

            Fade();
        }       
    }
}
