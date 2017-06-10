using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnDestroyable : MonoBehaviour {

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (SceneManager.GetActiveScene().name == "RealizationNowhere")
        {
            Destroy(gameObject);
        }
    }
}
