using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ytrigger : Switch
{

    public string narration_key;
    public float narrationLength;
    private Player player;

    public override void Activate()
    {
        Narrator.Instance.narrate(narration_key);
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player.DisableMovement("Backward");;
        StartCoroutine(Destruction(narrationLength));
    }

    IEnumerator Destruction(float time)
    {
        yield return new WaitForSeconds(time);
        player.EnableMovement();
        Destroy(this);

    }
}
