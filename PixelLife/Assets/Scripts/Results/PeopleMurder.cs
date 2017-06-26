using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class PeopleMurder : Murder
{
    //Act 3
    public Vector3 MurdererPosition1;

    //Act 4
    public float fieldOfView2;
    private float oldFieldOfView2;
    public Sprite BloodyRogerSprite;
    public Die Bob;
    public Die Carl;
    public Die Pauline;

    //Act 5
    public Vector3 MurdererPosition2;

    //Act 11
    public Vector3 MurdererPosition3;


    public override void Awake()
    {
        base.Awake();
        Hallucinate();
        SetupActs();
    }

    private void Hallucinate()
    {
        hallucinationEffect.mat.SetFloat("_yPercentage" , 0f);
    }

    private void SetupActs()
    {
        Acts = new List<act>();
        Acts.Add(Act1);
        Acts.Add(Act2);
        Acts.Add(Act3);
        Acts.Add(Act4);
        Acts.Add(Act5);
        Acts.Add(Act6);
        Acts.Add(Act7);
        Acts.Add(Act8);
        Acts.Add(Act9);
        Acts.Add(Act10);
        Acts.Add(Act11);
        Acts.Add(Act12);
        Acts.Add(Act13);
        Acts.Add(Act14);
        Acts.Add(Act15);
        Acts.Add(Act16);
        Acts.Add(Act17);
        Acts.Add(Act18);
        Acts.Add(Act19);
    }

    //Prepares
    private void Act1()
    {

    }

    private void Act2()
    {
        Narrator.Instance.GetComponent<AudioSource>().pitch = 1;
        Narrator.Instance.narrate("BobWhatAreYouDoing");
        Murderer.SetActive(true);
        CameraFlash();

    }

    private void Act3()
    {
        Murderer.transform.position = MurdererPosition1;
        CameraFlash();

    }

    private void Act4()
    {
        oldFieldOfView2 = camera.fieldOfView;
        camera.fieldOfView = fieldOfView2;

        SpriteRenderer murderenderer = Murderer.GetComponent<SpriteRenderer>();
        murderenderer.sprite = BloodyRogerSprite;
        murderenderer.flipX = true;
        CameraFlash();
    }

    private void Act5()
    {

        camera.fieldOfView = oldFieldOfView2;
        Murderer.transform.position = MurdererPosition2;
        Narrator.Instance.narrate("BobYell");
        CameraFlash();

    }

    private void Act6()
    {
        Bob.GetComponent<SpriteRenderer>().sortingOrder = 1;
        Bob.Execute();
        CameraFlash();
    }

    private void Act7()
    {
        CameraFlash();
        SoundEffector.Instance.play("DUN DUN DUN");
    }

    private void Act8()
    {
        SpriteRenderer murderenderer = Murderer.GetComponent<SpriteRenderer>();
        murderenderer.flipX = false;
    }

    private void Act9()
    {
        //Kills Time
    }

    private void Act10()
    {
        CameraFlash();
        Narrator.Instance.narrate("CarlYell");
    }

    private void Act11()
    {

        Murderer.transform.position = MurdererPosition3;
        CameraFlash();

    }

    private void Act12()
    {
        Act9();
    }

    private void Act13()
    {
        CameraFlash();
        Carl.Execute();
        Narrator.Instance.narrate("PaulineYell");
    }

    private void Act14()
    {
        CameraFlash();
        SpriteRenderer murderenderer = Murderer.GetComponent<SpriteRenderer>();
        murderenderer.flipX = true;
        Murderer.transform.Translate(new Vector3(-0.05f , 0f , 0f));
        pacingTime = 1f;
    }

    private void Act15()
    {
        CameraFlash();
        Murderer.transform.Translate(new Vector3(-0.05f , 0f , 0f));
    }

    private void Act16()
    {
        CameraFlash();
        Murderer.transform.Translate(new Vector3(-0.05f , 0f , 0f));
    }

    private void Act17()
    {
        CameraFlash();
        Murderer.transform.Translate(new Vector3(-0.05f , 0f , 0f));
    }

    private void Act18()
    {
        CameraFlash();
        Murderer.transform.Translate(new Vector3(-0.05f , 0f , 0f));
    }

    private void Act19()
    {
        CameraFlash();
        Pauline.Execute();
    }
}
