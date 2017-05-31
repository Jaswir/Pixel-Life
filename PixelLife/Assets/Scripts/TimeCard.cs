using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeCard : Result {

    public GameObject TimeCardGameObject;
    public string scene_name;

    private bool TimeCardActivated;
    private float timeCardDuration;
    private float timeCardTimer;

    public override void Execute(params float[] parameters)
    {
        DoTimeCard();
    }

    void DoTimeCard()
    {
        if (!TimeCardActivated)
        {
            TimeCardGameObject.SetActive(true);
            AudioSource audio = TimeCardGameObject.GetComponent<AudioSource>();
            audio.Play();
            timeCardDuration = audio.clip.length;
            TimeCardActivated = true;
        }
    }

    void ReturnFromTimeCard()
    {
        SceneManager.LoadScene(scene_name);
    }

    void Update()
    {
        if (TimeCardActivated)
        {
            timeCardTimer += Time.deltaTime;
            if (timeCardTimer >= timeCardDuration)
            {
                ReturnFromTimeCard();
            }
        }
    }
}
