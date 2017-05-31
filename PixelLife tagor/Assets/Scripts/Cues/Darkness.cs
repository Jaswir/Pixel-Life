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
            //Narrator.Instance.narrate(narration_key);
            Destroy(this);
        }
    }

    void Update()
    {
        startTimer += Time.deltaTime;
        if (startTimer >= fadeoutStartTime)
        {
            Fade();
            if (Credits != null)
            {
                Credits.SetActive(true);
            }
        }       
    }
}
