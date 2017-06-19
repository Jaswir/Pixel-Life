using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakMusicFor : Result
{
    private AudioSource BoomBox;

    void Awake()
    {
        BoomBox = GameObject.FindWithTag("BoomBox").GetComponent<AudioSource>();
    }

    public override void Execute(params float[] parameters)
    {
        BoomBox.Pause();
        StartCoroutine(StopMusicCoroutine(parameters[0]));
    }

    IEnumerator StopMusicCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        BoomBox.Play();
    }
}
