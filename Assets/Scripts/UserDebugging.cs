using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserDebugging : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        LoadNextLeveLImmediately();
        CollisionOnOrOff();
    }

    void LoadNextLeveLImmediately()
    {
        if (Input.GetKey(KeyCode.L))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(0);

            }
            else
            {
                SceneManager.LoadScene(currentSceneIndex + 1);

            }
        }
    }

    void CollisionOnOrOff()
    {
        if (Input.GetKey(KeyCode.C))
        {
            DisableCollisions();
        }
        else if (Input.GetKey(KeyCode.E))
        {
            EnableCollisions();
        }
    }

    void DisableCollisions()
    {
        
        Collider[] collisions = GameObject.FindObjectsOfType<Collider>();
        for (int i = 0; i < collisions.Length; i++)
        {

            collisions[i].enabled = false;
        }
        
    }

    void EnableCollisions()
    {
        
        Collider[] collisions = GameObject.FindObjectsOfType<Collider>();
        for (int i = 0; i < collisions.Length; i++)
        {

            collisions[i].enabled = true;
        }
        
    }
}
