using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffector : MonoBehaviour
{

    //simpleton pattern.
    public static SoundEffector Instance;
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
        foreach (AudioClip clip in Resources.LoadAll("Muziek/SoundEffects"))
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


    public void play(string name, float time = 0.0f)
    {
        //corner case empty string
        if (name != "" && name != null)
        {
            StartCoroutine(Play(time, name));
        }
    }
    private IEnumerator Play(float time, string name)
    {
        yield return new WaitForSeconds(time);
        audio.volume = 1.0f;
        audio.clip = audioCollection[name];
        audio.Play();
    }
    public void Stop()
    {
        audio.Stop();
    }
}
