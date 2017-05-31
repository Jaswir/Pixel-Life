using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unveil : MonoBehaviour
{


    private bool playerMoved;
    public GameObject hidden;
    public string soundeffect_key;

    // Update is called once per frame
    void Update()
    {

        if (!playerMoved)
        {
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) ||
                Input.GetKey(KeyCode.W)
                || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.D))
            {
                
                hidden.SetActive(false);
                SoundEffector.Instance.play(soundeffect_key);

                playerMoved = true;
                Destroy(this);
            }
        }



    }


}
