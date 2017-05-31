using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Switch : MonoBehaviour
{
    public string scene;

    void OnTriggerEnter2D(Collider2D other)
    {
        Activate();
    }

    private void Activate()
    {

        SceneManager.LoadScene(scene);
    }
}
