using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

public class Breakdown : Event
{
    public string narration_key;
    public Animator animator;

    public float flickerTimeOffset;
    public string flicker_soundeffect_key;
    private bool flickered;

    public float knifeTimeOffset;
    public SpriteRenderer roomRenderer;
    public Sprite noKnifeSprite;
    public Sprite knifeSprite;
    private bool knifed;

    public float rogerDaggerOffset;
    public SpriteRenderer rogerRenderer;
    public Sprite rogerDagger;
    private bool roggerDaggered;

    public float bloodyRogerOffset;
    public Sprite bloodyRoger;
    private bool bloodied;

    public float lostItOffset;
    public string lostIt_soundeffect_key;
    private bool lostIt;


    public float walkSequence0Time;
    public float walkSequence1Time;
    public float walkSequence2Time;
    public Player player;

    public float weirdAboutDeskTime;
    public float weirdAboutDeskZoomTime;
    private float weirdAboutDeskZoomTimer;
    private bool weirdedOutHisDesk;

    public float justLoseItTime;
    public Vector3 justLoseItCamPosition;
    public Vector3 justLoseItPosition;
    private bool justLostIt;

    public float blackScreenTimeOffset;
    public float blackScreenTime0;
    private float blackScreenTimer;
    private bool blackScreened;

    public float noiseScareOffset;
    public float noiseScareTime;
    public NoiseAndGrain noiseAndGrain;
    private float noiseScareTimer;
    private bool noiseScarred;

    public float switchTime;
    public string switchScene;

    public float timer;
    private bool isRunning;

    void Start()
    {
        player.DisableMovement();
    }

    public override void Run()
    {
        isRunning = true;      
        Narrator.Instance.narrate(narration_key);
    }

    void Update()
    {
        if (isRunning)
        {
            GoesToWork();
            WeirdAboutHisDesk();
            JustLoseIt();
            BlackScreen();
            ScaryNoise();

            HandleFlicker();
            HandleKnifeImageSetting();
            HandleRogerDaggerImageSetting();
            HandleBloodyKnifeImageSetting();
            LostItSoundEffect();
            SceneSwitch();

            timer += Time.deltaTime;
        }
    }


    private void ScaryNoise()
    {
        if (!noiseScarred)
        {
            if (timer >= noiseScareOffset)
            {
                noiseScareTimer += Time.deltaTime / noiseScareTime;
                noiseAndGrain.softness = Mathf.Lerp(0f, 1f, noiseScareTimer);

                if (noiseScareTimer >= noiseScareTime)
                {
                    noiseAndGrain.enabled = false;
                    roomRenderer.color = Color.black;
                    rogerRenderer.color = Color.black;
                    noiseScarred = true;  
                }
            }
        }
    }
    private void BlackScreen()
    {
        if (!blackScreened)
        {
            if (timer >= blackScreenTimeOffset)
            {
                //Sets black screen
                if (animator.enabled)
                {
                    animator.enabled = false;
                    roomRenderer.color = Color.black;
                    rogerRenderer.color = Color.black;
                    ;
                }

                //Returns white screen
                if (blackScreenTimer >= blackScreenTime0)
                {
                    roomRenderer.color = Color.white;
                    rogerRenderer.color = Color.white;
                    noiseAndGrain.enabled = true;
                    blackScreened = true;
                }

                blackScreenTimer += Time.deltaTime;
            }
        }
    }
    private void JustLoseIt()
    {
        if (timer >= justLoseItTime)
        {
            Camera.main.transform.position = justLoseItCamPosition;
            Camera.main.fieldOfView = 4f;
            player.transform.position = justLoseItPosition;
            justLostIt = true;
        }
    }
    private void WeirdAboutHisDesk()
    {
        if (!weirdedOutHisDesk)
        {
            if (timer >= weirdAboutDeskTime)
            {
                weirdAboutDeskZoomTimer += Time.deltaTime / weirdAboutDeskZoomTime;
                Camera.main.fieldOfView = Mathf.Lerp(23f, 8f, weirdAboutDeskZoomTimer);

                if (weirdAboutDeskZoomTimer >= weirdAboutDeskZoomTime)
                {
                    weirdedOutHisDesk = true;
                }
            }
        }
    }
    private void GoesToWork()
    {
        player.DisableMovement();
        if (timer <= walkSequence0Time)
        {
            player.SimulateMovement(true, false, false, false);
        }
        else if (timer <= walkSequence1Time)
        {
            player.SimulateMovement(true, false, false, true);
        }
        else if (timer <= walkSequence2Time)
        {
            player.SimulateMovement(false, false, false, true);
        }
    }

    private void LostItSoundEffect()
    {
        if (!lostIt)
        {
            if (timer >= lostItOffset)
            {
                SoundEffector.Instance.play(lostIt_soundeffect_key);
                lostIt = true;
            }
        }
    }
    private void HandleBloodyKnifeImageSetting()
    {
        if (!bloodied)
        {
            if (timer >= bloodyRogerOffset)
            {
                rogerRenderer.sprite = bloodyRoger;
                bloodied = true;
            }
        }
    }
    private void HandleRogerDaggerImageSetting()
    {
        if (!roggerDaggered)
        {
            if (timer >= rogerDaggerOffset)
            {
                roomRenderer.sprite = noKnifeSprite;
                rogerRenderer.sprite = rogerDagger;
                rogerRenderer.GetComponent<Animator>().enabled = false;
                roggerDaggered = true;
            }
        }
    }
    private void HandleKnifeImageSetting()
    {
        if (!knifed)
        {
            if (timer >= knifeTimeOffset)
            {
                roomRenderer.sprite = knifeSprite;
                knifed = true;
            }
        }
    }
    private void HandleFlicker()
    {
        if (!flickered)
        {
            if (timer >= flickerTimeOffset)
            {
                SoundEffector.Instance.play(flicker_soundeffect_key);
                animator.enabled = true;
                flickered = true;
            }

        }
    }

    private void SceneSwitch()
    {
        if (timer >= switchTime)
        {
            SceneManager.LoadScene(switchScene);
            Destroy(this);
        }
    }

}
