using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] AudioClip crashClip;
    [SerializeField] AudioClip finishClip;

    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem finishParticle;

    AudioSource audioSource;

    bool isTransitioning = false;

    // Start
    void Start()
    {
         audioSource = GetComponent<AudioSource>();
    }

    // creates branching structure for how to react based on what is collided into
    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning)
        {
            return;
        }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finished":
                StartNewLevelSequence();
                break;
            default:
                StartCrashSequenece();
                break;
        }
    }


    // runs sequence when player crashes, disables controls and reloads level
    // after a delay
    void StartCrashSequenece()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashClip, 0.5f);
        crashParticle.Play();
        Movement moveScript = GetComponent<Movement>();
        moveScript.enabled = false;
        Invoke("ReloadLevel", 2f);
    }


    // runs sequenece when player finishes level, disables controls and loads
    // next level after a delay 
    void StartNewLevelSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(finishClip, 0.5f);
        Movement moveScript = GetComponent<Movement>();
        moveScript.enabled = false;
        finishParticle.Play();
        Invoke("LoadNextLevel", loadDelay);
    }


    // responsible for reloading the level 
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }


    // responsible for loading the next level
    void LoadNextLevel()
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
