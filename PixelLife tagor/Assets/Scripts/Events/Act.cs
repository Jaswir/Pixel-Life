using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Act : Event
{
    public Player player;
    public Camera camera;

    [Tooltip("Effects the Zoom, lower value is more zoom")]
    public float fieldOfView;
    private float oldFieldOfView;
    public Vector2 playerPosition;
    private Vector2 oldPlayerPosition;
    public Vector3 zoomPosition;
    private Vector3 oldCamPosition;
    private bool curtainsOpen;


    public override void Run()
    {
        PrepareAndOpenCurtains();
    }

    private void PrepareAndOpenCurtains()
    {    
        DisableMovement();
        PositionCharacters();
        PositionCamera();
        ZoomIn();

        HUD.Instance.SetActivity(true); ;
        curtainsOpen = true;
    }

    private void DisableMovement()
    {
        player.movementEnabled = false;
    }
    private void PositionCharacters()
    {
        oldPlayerPosition = player.transform.position;
        player.transform.position = playerPosition;
    }   
    private void PositionCamera()
    {
        oldCamPosition = camera.transform.position;
        camera.transform.position = zoomPosition;
    }
    private void ZoomIn()
    {
        oldFieldOfView = camera.fieldOfView;
        camera.fieldOfView = fieldOfView;
    }

    private void CloseCurtains()
    {
        EnableMovement();
        FreeCharacterPositions();
        FreeCameraPosition();    
        ZoomOut();

        audioSource.Stop();
        HUD.Instance.SetActivity(false);
        curtainsOpen = false;
    }

    private void EnableMovement()
    {
        player.movementEnabled = true;
    }
    private void FreeCameraPosition()
    {
        camera.transform.position = oldCamPosition;
    }
    private void FreeCharacterPositions()
    {
        player.transform.position = oldPlayerPosition;
    }
    private void ZoomOut()
    {
        camera.transform.SetParent(null);
        camera.fieldOfView = oldFieldOfView;
    }

    private void NarrateClose()
    {   
        if (narration_key != "")
        {
            Narrator.Instance.narrate(narration_key);
        } 
    }

    public string[] Lines;
    public AudioClip[] audioClips;
    public string narration_key;
    private AudioSource audioSource;
    private int stage = -1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (curtainsOpen)
        {
            //Upon Click or Space => 
            bool clickOrSpace = Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
            if (clickOrSpace || !audioSource.isPlaying)
            {
                //next line + audio
                stage++;

                if (stage >= Lines.Length)
                {
                    NarrateClose();
                    CloseCurtains();
                    return;
                }

                HUD.Instance.SetLines(Lines[stage]);
                Narrator.Instance.sssSSSHHHHH();
                audioSource.clip = audioClips[stage];
                audioSource.Play();
            }
        }

    }


}
