using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nowhere : Event
{
    public int chains;

    public override void Run()
    {
        ReleaseDarkness();
    }

    public void Unchain()
    {
        chains--;
        bool unchained = chains == 0;
        if(unchained)
        {
            Run();
        }
    }

    private void ReleaseDarkness()
    {
        GetComponent<Darkness>().enabled = true;
        Destroy(this);
    }

}
