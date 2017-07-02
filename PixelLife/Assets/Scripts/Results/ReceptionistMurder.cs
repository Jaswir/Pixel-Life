using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class ReceptionistMurder : Murder
{
    private AudioSource backupAdio;

    //Acts
    public GameObject BloodyRoger;
    public Vector3 bloodyRogerPosition1;
    public Vector3 bloodyRogerPosition2;
    public Vector3 bloodyRogerPosition3;
    public Vector3 bloodyRogerPosition4;
    public Vector3 bloodyRogerPosition5;
    public Vector3 bloodyRogerPosition6;
    public Vector3 victimDeathPos;
    public Vector3 zoomPosition2;
    public float fieldOfView2;
    public RuntimeAnimatorController BloodyController;

    public override void Awake()
    {
        base.Awake();
        backupAdio = GetComponent<AudioSource>();
        SetupActs();
    }

    public override void BreakDownStage()
    {
        base.BreakDownStage();
        Roger.GetComponent<Animator>().runtimeAnimatorController = BloodyController;
    }

    private void SetupActs()
    {
        Acts = new List<act>();
        Acts.Add(Act1);
        Acts.Add(Act2);
        Acts.Add(EmptyAct);
        Acts.Add(HeartBeatAct);
        Acts.Add(EmptyAct);
        Acts.Add(Act3);
        Acts.Add(HeartBeatAct);
        Acts.Add(EmptyAct);
        Acts.Add(Act4);
        Acts.Add(HeartBeatAct);
        Acts.Add(EmptyAct);
        Acts.Add(Act5);
        Acts.Add(HeartBeatAct);
        Acts.Add(EmptyAct);
        Acts.Add(Act6);
        Acts.Add(EmptyAct);
        Acts.Add(EmptyAct);
    }

    private void EmptyAct()
    {
       
    }

    private void HeartBeatAct()
    {
        Narrator.Instance.narrate("heartbeat");
    }

    private void Act1()
    {
        CameraFlash();
        BloodyRoger.SetActive(true);
        BloodyRoger.transform.position = bloodyRogerPosition1;
    }

    private void Act2()
    {
        CameraFlash();
        Narrator.Instance.narrate("gaspFemale");
        Narrator.Instance.GetComponent<AudioSource>().pitch = 1.0f;
        BloodyRoger.transform.position = bloodyRogerPosition2;
    }

    private void Act3()
    {
        CameraFlash();
        backupAdio.pitch = 0.6f;
        backupAdio.Play();
        BloodyRoger.transform.position = bloodyRogerPosition3;
    }


    private void Act4()
    {
        SoundEffector.Instance.play("kastToe");
        BloodyRoger.GetComponent<SpriteRenderer>().flipX = true;
        backupAdio.pitch = 0.8f;
        backupAdio.Play();
        BloodyRoger.transform.position = bloodyRogerPosition4;
    }

    private void Act5()
    {
        CameraFlash();
        backupAdio.pitch = 1f;
        backupAdio.Play();
        BloodyRoger.transform.position = bloodyRogerPosition5;
    }

    private void Act6()
    {
        CameraFlash();
        BloodyRoger.transform.position = bloodyRogerPosition6;
        BloodyRoger.GetComponent<SpriteRenderer>().flipX = true;
        Victims.transform.position = victimDeathPos;
        Victims.transform.GetChild(0).GetComponent<Die>().Execute();
        camera.transform.position = zoomPosition2;
        camera.fieldOfView = fieldOfView2;
    }
}
