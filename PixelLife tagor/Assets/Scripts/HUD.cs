using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    //simpleton pattern.
    public static HUD Instance;
    public GameObject panel;
    public Text lines;

    void Awake()
    {
        ApplySingleton();
    }

    public void SetLines(string text)
    {
        lines.text = ">> " + text;
    }

    public void SetActivity(bool activity)
    {
        lines.gameObject.SetActive(activity);
        panel.SetActive(activity);
    }

    /// <summary>
    /// Applies the singleton pattern.
    /// </summary>
    private void ApplySingleton()
    {
        //Singleton 
        if (HUD.Instance == null)
            HUD.Instance = this;

        if (this != HUD.Instance)
            Destroy(gameObject);
    }
}
