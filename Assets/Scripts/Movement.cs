using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource thrustSound;

    // handles the thrust speed 
    [SerializeField] float yThrust = 1f;

    // handles the rotation speed 
    [SerializeField] float rotationThrust = 1f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thrustSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {   
        ProcessThrust();
        ProcessRotation();
    }

    // processes thrust action if user is holding down space bar
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            rb.AddRelativeForce(Vector3.up * yThrust * Time.deltaTime);
            if (!thrustSound.isPlaying)
            {
                thrustSound.Play(); 
            }

        }
        else
        {
            
            thrustSound.Stop();
        }
    }

    // processes rotate action if user is holding down A (left) or D (right)
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);

        }
    }

   // rotates the rocket forward or back depending on if rotationThisFrame is positive or negative 
   void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

}
