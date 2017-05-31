using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAnim : MonoBehaviour {

    // Use this for initialization
    public GameObject StartButton;
    public SpriteRenderer Background;
    public GameObject Letters;
    private float Timer=0.0f;
    private Color CurColor;
    [SerializeField]
    private Color color1;
    [SerializeField]
    private Color color2;
    private float Total = 0.0f;

    void Start () {
        StartButton.SetActive(false);
        Letters.SetActive(false);
        Color curColor = Background.color;
        curColor.a = -1.0f;
        Background.color = curColor;
    }

    // Update is called once per frame
    void Update() {
        Timer += 1 * Time.deltaTime;
        Color curColor = Background.color;

        if (curColor.a < 1.0f)
        { 
        curColor.a = Total+ 0.01f*Time.deltaTime;
        Background.color = curColor;
         Total += 0.002f;
            Debug.Log(Total);
        }
        if (Total > 0.9f)
        {
            Letters.SetActive(true);
        }
    if(Timer > 12 && Timer < 13)
        {
            StartButton.SetActive(true);
        }
    }
}
