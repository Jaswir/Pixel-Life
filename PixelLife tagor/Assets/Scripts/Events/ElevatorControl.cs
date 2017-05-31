using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControl : Event
{
    public GameObject ElevatorCollider;
    public SpriteRenderer elevatorClosed;
    public Sprite elevatorOpen;

    public override void Run()
    {
        OpenElevator();
    }

    void OpenElevator()
    {
        ElevatorCollider.SetActive(false);
        elevatorClosed.sprite = elevatorOpen;
    }
}
