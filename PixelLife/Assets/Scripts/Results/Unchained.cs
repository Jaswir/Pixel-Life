using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unchained : Result
{
    public Nowhere noWhere;
    public bool stopMusic;
    private AudioSource BoomBox;

    void Awake()
    {
        BoomBox = GameObject.FindWithTag("BoomBox").GetComponent<AudioSource>();
    }

    public override void Execute(params float[] parameters)
    {
        if(stopMusic)
            BoomBox.Pause();

        StartCoroutine(UnchainCoroutine(parameters[0]));
    }

    IEnumerator UnchainCoroutine(float time)
    {
        noWhere.Unchain();
        yield return new WaitForSeconds(time);

        

        if(stopMusic)
            BoomBox.Play();
    }
}
