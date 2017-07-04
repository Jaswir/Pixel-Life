using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Realization : MonoBehaviour
{
    public AudioSource audioSource;
    public Animator animator;
    public SpriteRenderer room;

    private bool lightTurnedOff;
    private float timer;

    void Update()
    {
        if (audioSource.clip != null)
        {
            timer += Time.deltaTime;

            if (!lightTurnedOff)
            {
                if (timer >= audioSource.clip.length)
                {
                    TurnOffLight();
                    RunEvent();

                }
            }
        }
    }

    void RunEvent()
    {
        Event Event = GetComponent<Event>();
        Event.Run();
    }

    void TurnOffLight()
    {
        room.color = Color.white;
        animator.enabled = false;
        lightTurnedOff = true;
    }

}
