using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControl : Event
{
    public GameObject ElevatorCollider;
    public SpriteRenderer elevatorClosed;
    public Sprite elevatorOpen;

    private AudioSource audio;

    public override void Run()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
        StartCoroutine(OpenElevator(audio.clip.length));
    }

    IEnumerator OpenElevator(float time)
    {
        yield return new WaitForSeconds(time);
        audio.Stop();
        ElevatorCollider.SetActive(false);
        elevatorClosed.sprite = elevatorOpen;
    }
}
