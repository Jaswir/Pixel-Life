using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration : Event
{
    public string narration_key;

    public override void Run()
    {
        Narrator.Instance.narrate(narration_key);
    }
}
