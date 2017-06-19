using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narration : Event
{
    public string narration_key;
    public bool hasResult;

    public override void Run()
    {
        Narrator.Instance.narrate(narration_key);
        if (hasResult)
        {
            Result result = GetComponent<Result>();
            result.Execute(Narrator.Instance.getNarrationLength(narration_key));
        }
    }
}
