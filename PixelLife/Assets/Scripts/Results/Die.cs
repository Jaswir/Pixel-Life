using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : Result
{
    public Sprite ChangeSprite;

    public override void Execute(params float[] parameters)
    {
        GetComponent<SpriteRenderer>().sprite = ChangeSprite;
    }
}
