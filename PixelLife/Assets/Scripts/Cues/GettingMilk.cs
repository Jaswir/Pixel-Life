using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class GettingMilk : Switch
{
    public SpriteRenderer roomSpriteRenderer;
    public Sprite afterSpriteRoom;
    public GameObject AFewMomentsLater;
    public string narration_key;
    public float narration_waitTime;
    public Player Roger;
    public GameObject Bottles;
    public Vector3 playerSpawnPosition;

    private bool TimeCardActivated;
    private float timeCardDuration;
    private float timeCardTimer;

    public bool hasResult;



    public override void Activate()
    {
        DoTimeCard();
    }

    void DoTimeCard()
    {
        if (!TimeCardActivated)
        {
            AFewMomentsLater.SetActive(true);
            AudioSource audio = AFewMomentsLater.GetComponent<AudioSource>();
            audio.Play();
            timeCardDuration = audio.clip.length;
            TimeCardActivated = true;
        }
    }

    void ReturnFromTimeCard()
    {
        ChangeRooms();
        Roger.transform.position = playerSpawnPosition;
        Roger.movementEnabled = false;
        Bottles.SetActive(true);
        AFewMomentsLater.SetActive(false);

        Narrator.Instance.narrate(narration_key, 3.0f);
        Invoke("ExecuteResults", 3.0f);

        Destroy(this);
    }

    private void ExecuteResults()
    {
        if (hasResult)
        {
            Result result = GetComponent<Result>();
            result.Execute();
        }
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

    void ChangeRooms()
    {
        roomSpriteRenderer.sprite = afterSpriteRoom;
    }
}
