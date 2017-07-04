using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TransitionState
{
    Evap,
    Invert,
    Done
}

public class TransitionPart2 : Event
{
    public Material halluMat;
    public Material evaporateMat;
    public float minMagnitude;
    public float maxMagnitude;

    public float transitionTime;
    private float transitionTimer;


    public float inversionTime;
    private float inversionTimer;
    public TransitionState tsState;

    private bool update;

    public override void Run()
    {
        Narrator.Instance.narrate("tension");
        update = true;

    }

    void Start()
    {
        evaporateMat.SetFloat("_Magnitude" , 0f);
        halluMat.SetFloat("_yPercentage" , 1f);
    }
    // Update is called once per frame
    void Update()
    {
        if(update)
        {
            if(tsState == TransitionState.Evap)
            {
                transitionTimer += Time.deltaTime / transitionTime;
                float magnitude = Mathf.Lerp(minMagnitude , maxMagnitude , transitionTimer);
                evaporateMat.SetFloat("_Magnitude" , magnitude);

                if(transitionTimer >= 1)
                {
                    //De-evaporate
                    evaporateMat.SetFloat("_Magnitude" , minMagnitude);
                    halluMat.SetFloat("_yPercentage" , 0f);
                    tsState = TransitionState.Invert;
                }
            }

            else if(tsState == TransitionState.Invert)
            {
                inversionTimer += Time.deltaTime;
                if(inversionTimer > inversionTime)
                {
                    halluMat.SetFloat("_yPercentage" , 1f);
                    SoundEffector.Instance.Stop();
                    tsState = TransitionState.Done;
                }
            }
        }
    }

}
