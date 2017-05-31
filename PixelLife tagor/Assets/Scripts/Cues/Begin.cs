using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Begin : MonoBehaviour
{
    public string narration_key;

    void Start()
    {
        Narrator.Instance.narrate(narration_key);       
    }
}
