using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class Murder : Result
{
    protected delegate void act();
    protected List<act> Acts;
    private int count = 0;
    public float pacingTime;
    private float pacingTimer;
    private bool openingCurtains;
    private bool curtainsOpened;
    private float openingTime;
    private float openingTimer;
    private bool closingCurtains;
    private float closingTimer;

    public PPImageEffect hallucinationEffect;
    public float remainingHallucination;
    public VignetteAndChromaticAberration vignetteEffect;
    public float fieldOfView;
    private float oldFieldOfView;
    public Vector3 zoomPosition;
    private Vector3 oldCamPosition;
    protected Camera camera;

    public GameObject Roger;
    public GameObject Victims;
    public GameObject Murderer;
    public GameObject Path;
 

    public virtual void Awake()
    {
        camera = Camera.main;
    }

    public override void Execute(params float[] parameters)
    {
        SetupStage();
    }

    public void CameraFlash()
    {
        SoundEffector.Instance.play("camFlash");
    }

    /// <summary>
    /// Things are placed/ removed from stage,
    /// positions are taken for show
    /// </summary>
    void SetupStage()
    {
        _Dis_ActivatesStuff();
        Positions();
        SoundIntroduction();
    }

    public virtual void SoundIntroduction()
    {
        SoundEffector.Instance.play("appears");
        openingTime = SoundEffector.Instance.getEffectLength("appears");
        openingCurtains = true;
    }
    public virtual void Positions()
    {
        oldCamPosition = camera.transform.position;
        camera.transform.position = zoomPosition;
        oldFieldOfView = camera.fieldOfView;
        camera.fieldOfView = fieldOfView;
    }
    public virtual void _Dis_ActivatesStuff()
    {
        Victims.SetActive(true);
        Roger.SetActive(false);
        hallucinationEffect.enabled = false;
        vignetteEffect.enabled = true;
    }

    void Update()
    {
        if(openingCurtains)
        {
            OpenCurtains();
        }

        else if(curtainsOpened)
        {
            PlayActs();
        }

        else if(closingCurtains)
        {
            CloseCurtains();
        }
    }

    void OpenCurtains()
    {
        openingTimer += Time.deltaTime / openingTime;
        vignetteEffect.intensity = Mathf.Lerp(1.0f , 0.43f , openingTimer);

        if(openingTimer >= 1f)
        {
            openingCurtains = false;
            curtainsOpened = true;
        }
    }
    void CloseCurtains()
    {
        closingTimer += Time.deltaTime / openingTime;
        vignetteEffect.intensity = Mathf.Lerp(0.43f , 1.0f , closingTimer);

        if(closingTimer >= 1f)
        {
            closingCurtains = false;
            BreakDownStage();

        }
    }
    public virtual void BreakDownStage()
    {
        Roger.SetActive(true);
        Murderer.SetActive(false);

        hallucinationEffect.enabled = true;
        vignetteEffect.intensity = 0.43f;
        vignetteEffect.enabled = false;

        camera.fieldOfView = oldFieldOfView;
        camera.transform.position = oldCamPosition;
        hallucinationEffect.mat.SetFloat("_yPercentage" , remainingHallucination);
        Path.SetActive(false);
    }
    private void PlayActs()
    {
        pacingTimer += Time.deltaTime;
        if(pacingTimer >= pacingTime)
        {
            if(count >= Acts.Count)
            {
                curtainsOpened = false;
                closingCurtains = true;

                return;
            }

            Acts[count]();
            count++;
            pacingTimer = 0.0f;
        }
    }


}
