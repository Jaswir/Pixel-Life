using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFeel : MonoBehaviour
{

    public string inputText;
    public float letterFlowTime;

    private Text text;
    private int textLength;
    private int textCounter;
    private float textFlowTimer;
    private bool toUpdate;

	// Use this for initialization
	void Start ()
	{
	    toUpdate = true;
	    text = GetComponent<Text>();
	    textLength = inputText.Length - 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (toUpdate)
        {
            if (textCounter <= textLength)
            {
                //Types the next letter every flowSpeed
                textFlowTimer += Time.deltaTime;
                if (textFlowTimer >= letterFlowTime / 1000f)
                {
                    textFlowTimer = 0.0f;
                    text.text += inputText[textCounter];
                    textCounter++;
                }
            }
        }
    }

    public void ClearText()
    {
        toUpdate = false;
        textCounter = 0;
        textLength = inputText.Length - 1;
        text.text = "";
        toUpdate = true;
    }
}
