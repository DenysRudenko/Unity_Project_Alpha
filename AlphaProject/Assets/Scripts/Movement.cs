using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rb;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
       audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    // Method for rocket to fly up and sound for rocket
   void ProcessThrust()
   {
        if (Input.GetKey(KeyCode.Space))
        {   
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        } else {
            audioSource.Stop();
        }
   }

    // Method for tocket to rotate left and right
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

    // Method for rotation than PrecessRotation is using for turning our rocket
   public void ApplyRotation(float rotationThisFrame)
   {
    rb.freezeRotation = true;   // freezing rotating so we can manually rotate
    transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
    rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
   }
}
