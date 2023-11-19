using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    // Method for rocket to fly up
   void ProcessThrust()
   {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
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
