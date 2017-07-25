using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    //simpleton pattern.
    public static HUD Instance;
    public GameObject panel;
    public Text lines;
    public float letterFlowTime = 20f;

    private int textLength;
    private int textCounter;
    private float textFlowTimer;
    private string inputText;
    private bool updateText;


    void Awake()
    {
        ApplySingleton();
    }

    public void SetLines(string text)
    {
        textCounter = 0;
        string[] residuTexts = text.Split(':');
        inputText = residuTexts[1];
        textLength = inputText.Length - 1;
        lines.text = ">>  " + residuTexts[0] + ":";
        updateText = true;

    }

    void Update()
    {
        if(updateText)
        {
            //Types the next letter every flowSpeed
            textFlowTimer += Time.deltaTime;
            if(textFlowTimer >= letterFlowTime / 1000f)
            {
                textFlowTimer = 0.0f;
                lines.text += inputText[textCounter];
                textCounter++;
            }

            if(textCounter > textLength)
            {
                updateText = false;
            }

        }
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
        if(HUD.Instance == null)
            HUD.Instance = this;

        if(this != HUD.Instance)
            Destroy(gameObject);
    }
}
