using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Narrator : MonoBehaviour
{

    //simpleton pattern.
    public static Narrator Instance;
    private AudioSource audio;
    private Dictionary<string , AudioClip> audioCollection = new Dictionary<string , AudioClip>();

    void Awake()
    {
        ApplySingleton();
        audio = GetComponent<AudioSource>();
        SetupAudioCollection();
    }

    private void SetupAudioCollection()
    {
        foreach(AudioClip clip in Resources.LoadAll("Muziek/Narrator"))
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
        if(Instance == null)
            Instance = this;

        if(this != Instance)
            Destroy(gameObject);
    }

    public float getNarrationLength(string clipName)
    {
        return audioCollection[clipName].length;
    }

    public void narrate(string name , float time = 0.0f)
    {
        StartCoroutine(Narrate(time , name));
    }
    private IEnumerator Narrate(float time , string name)
    {
        yield return new WaitForSeconds(time);
        audio.clip = audioCollection[name];
        audio.Play();
    }
    public void sssSSSHHHHH()
    {
        audio.Stop();
    }
}
