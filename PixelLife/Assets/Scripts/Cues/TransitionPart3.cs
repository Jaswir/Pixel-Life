using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class TransitionPart3 : Event
{
    public VignetteAndChromaticAberration VignAndChrom;
    public PPImageEffect hallucination;
    public Material halluMat;
    public Material evaporateMat;

    public Player player;
    public GameObject skitzo;
    public Material defaultHallu;

    public float minMagnitude;
    public float maxMagnitude;

    public float crazyExplosionTime;
    private float crazyExplosiontimer;

    void Start()
    {
        player.DisableMovement("");
        InitializeShaders();

        //Shockwave
        SoundEffector.Instance.play("shockWave");
        crazyExplosionTime = SoundEffector.Instance.getEffectLength("shockWave");
    }

    // Update is called once per frame
    void Update()
    {
        //Have crazy effect explosion
        crazyExplosiontimer += Time.deltaTime/crazyExplosionTime;
        float magnitude = Mathf.Lerp(minMagnitude , maxMagnitude , crazyExplosiontimer);
        float chromAbb = Mathf.Lerp(0, 800f, crazyExplosiontimer);
        evaporateMat.SetFloat("_Magnitude" , magnitude);
        VignAndChrom.chromaticAberration = chromAbb;

        //Ends with setting the default shader effect
        if(crazyExplosiontimer >= 1)
        {
            hallucination.mat = defaultHallu;
            InitializeShaders();
            player.EnableMovement();
            skitzo.SetActive(true);
            Destroy(this);
        }
    }

    private void InitializeShaders()
    {
        VignAndChrom.chromaticAberration = 0.0f;
        evaporateMat.SetFloat("_Magnitude" , 0f);
        halluMat.SetFloat("_yPercentage" , 1f);
    }

}
