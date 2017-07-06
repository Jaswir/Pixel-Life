using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RogerHouseEnding : MonoBehaviour {

    // Use this for initialization

    public GameObject Family;
    public GameObject Animation;
    public GameObject Woman;
    public GameObject PlayerSet;
    public Player _Player;
    public AudioSource EndMu;
    private float Timer=0;
    private bool Kneel = false;
    private bool activation = false;
    public string scene;

	void Start () {
        Family.SetActive(false);
        Animation.SetActive(false);
        Woman.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
    

        if(Kneel== true)
        {
            Timer += 1;

            if (Timer> 200)
            {
                PlayerSet.SetActive(false);
                Animation.SetActive(true);
                Kneel = false;
                activation = true;
            }
        }
        if (activation == true)
        {
            Timer += 1;
            if (Timer > 1500)
            {
                SceneManager.LoadScene(scene);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _Player.movementEnabled = false;
            Kneel = true;
            Family.SetActive(true);
            Woman.SetActive(true);
            EndMu.Play();
        }
    }
    
}
