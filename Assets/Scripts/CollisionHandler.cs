using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You ran into something Friendly");
                break;
            case "Finished":
                Debug.Log("You ran into the Finish");
                break;
            case "Fuel":
                Debug.Log("You ran into Fuel");
                break;
            default:
                Debug.Log("You ran into something harmful");
                break;
        }
    }
}
