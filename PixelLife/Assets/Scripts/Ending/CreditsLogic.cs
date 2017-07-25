using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsLogic : MonoBehaviour
{

    public float fadeoutTime;
    public float fadeoutStartTime;
    public float endTime;
    public bool hasEndTime = false;

    private SpriteRenderer spriteRenderer;
    private float fadeoutTimer;
    private float startTimer;
    public float endTimer;
    public GameObject Credits;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (Credits != null)
        {
            Credits.SetActive(false);
        }
    }

    void Fade()
    {
        fadeoutTimer += Time.deltaTime / fadeoutTime;

        Color curColor = spriteRenderer.color;
        curColor.a = Mathf.Lerp(1.0f, 0.0f, fadeoutTimer);
        spriteRenderer.color = curColor;

        if (fadeoutTimer >= fadeoutTime)
        {
            Destroy(this);
        }
    }

    void Update()
    {
        startTimer += Time.deltaTime;
        if(startTimer >= fadeoutStartTime)
        {
            Fade();
            if(Credits != null)
            {
                Credits.SetActive(true);
            }
        }

        if (hasEndTime)
        {
            endTimer += Time.deltaTime;
            if (endTimer >= endTime)
            {
                Credits.GetComponent<Animator>().Stop();
            }
        }
    }
}

