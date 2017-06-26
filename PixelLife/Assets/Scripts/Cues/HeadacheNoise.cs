using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class HeadacheNoise : Switch
{
    public bool realizing;
    public float noiseTimer;
    public float noiseTime;
    public float leftBoundary;
    public float rightBoundary;
    private float realizeTime;
    private float realizeTimer;

    public NoiseAndGrain noiseEffect;
    public bool hasResult;

    public override void Activate()
    {
        Realization();
    }

    void Realization()
    {
        GameObject.FindWithTag("Player").GetComponent<Player>().DisableMovement();
        SoundEffector.Instance.play("realization");
        realizeTime = SoundEffector.Instance.getEffectLength("realization");
        noiseEffect.enabled = true;
        realizing = true;
    }

    void Realize()
    {
        realizeTimer += Time.deltaTime;
        if(realizeTimer >= realizeTime)
        {
            realizing = false;
            noiseEffect.enabled = false;
            GameObject.FindWithTag("Player").GetComponent<Player>().EnableMovement();
            if (hasResult)
            {
                Result result = GetComponent<Result>();
                result.Execute();
            }
           
            Destroy(this);
            return;
        }

        //Moves the intensity toggle up and down
        noiseTimer += Time.deltaTime / noiseTime;
        noiseEffect.intensityMultiplier = Mathf.Lerp(leftBoundary , rightBoundary , noiseTimer);

        if(noiseTimer >= 1.0f)
        {
            float oldRightBoundary = rightBoundary;
            rightBoundary = leftBoundary;
            leftBoundary = oldRightBoundary;
            noiseTimer = 0.0f;
        }
    }

    void Update()
    {
        if(realizing)
        {
            Realize();
        }
    }
}
