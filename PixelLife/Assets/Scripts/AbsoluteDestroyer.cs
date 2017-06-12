using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsoluteDestroyer : MonoBehaviour {

    void Awake()
    {
        Destroy(GameObject.FindWithTag("BoomBox"));
    }
}
