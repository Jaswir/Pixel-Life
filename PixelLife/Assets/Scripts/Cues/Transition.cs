using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Player player;
    public PPImageEffect hallu;
    public Material evaporateMat;
    public float minMagnitude;
    public float maxMagnitude;
    public float transitionTime;
    private float transitionTimer;
    private bool playerMoved;

    private bool startedUpdate;

    void Start()
    {
        player.DisableMovement("");
        SoundEffector.Instance.play("realizationFlicker");
        float soundLength = SoundEffector.Instance.getEffectLength("realizationFlicker");
        evaporateMat.SetFloat("_Magnitude", 0f);
        hallu.mat.SetFloat("_yPercentage", 0f);
        Invoke("EnablePlayerMovement" , soundLength);

    }

    private void EnablePlayerMovement()
    {
        player.EnableMovement();
        startedUpdate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(startedUpdate)
        {
            if(!playerMoved)
            {
                if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) ||
                    Input.GetKey(KeyCode.W)
                    || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) ||
                    Input.GetKey(KeyCode.D))
                {
                    playerMoved = true;
                    SoundEffector.Instance.play("tension_0");
                }
            }

            else
            {
                transitionTimer += Time.deltaTime / transitionTime;
                float magnitude = Mathf.Lerp(minMagnitude , maxMagnitude , transitionTimer);
                evaporateMat.SetFloat("_Magnitude" , magnitude);

                if(transitionTimer >= 1)
                {
                    //De-evaporate
                    evaporateMat.SetFloat("_Magnitude" , minMagnitude);
                    SoundEffector.Instance.Stop();
                }
            }
        }
    }
}
