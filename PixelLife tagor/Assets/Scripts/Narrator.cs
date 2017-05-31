using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrator : MonoBehaviour {

    //simpleton pattern.
    public static Narrator Instance;
    private AudioSource audio;
    private Dictionary<string, AudioClip> audioCollection = new Dictionary<string, AudioClip>();

    void Awake()
    {
        ApplySingleton();
        audio = GetComponent<AudioSource>();
        SetupAudioCollection();
    }

    private void SetupAudioCollection()
    {
        foreach (AudioClip clip in Resources.LoadAll("Muziek/Narrator"))
        {
            audioCollection[clip.name] = clip;
        }
    }

    /// <summary>
    /// Applies the singleton pattern.
    /// </summary>
    private void ApplySingleton()
    {
        //Singleton 
        if (Instance == null)
            Instance = this;

        if (this != Instance)
            Destroy(gameObject);
    }


    public void narrate(string name)
    {
        audio.volume = 1.0f;
        audio.clip = audioCollection[name];
        audio.Play();
    }
    public void sssSSSHHHHH()
    {
        audio.Stop();
    }
}
