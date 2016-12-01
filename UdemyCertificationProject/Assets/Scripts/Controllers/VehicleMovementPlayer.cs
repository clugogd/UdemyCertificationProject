using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovementPlayer : VehicleMovement {

    

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        topSpeed = 20.0f;
        GetAllWheelsColliders();
    }

    // Update is called once per frame
    void Update ()
    {
        Grounded();

        if (isGrounded)
        {
            //  Get the user input for our values
            float turnX = Input.GetAxis("Horizontal");
            float moveForward = Input.GetAxis("Vertical") * topSpeed;

            Debug.Log("Turn Angle: " + turnX);

            //  Clamp them so they fit our ranges
            moveForward = Mathf.Clamp(moveForward, -topSpeed, topSpeed) * Time.deltaTime;
            turnX = Mathf.Clamp(turnX, -turnAngleABS, turnAngleABS);

            Debug.Log("Turn Angle Clamped: " + turnX);

            //  Apply the current values
            transform.Translate(transform.forward * moveForward, Space.World);
            transform.Rotate(transform.up, turnX);
        }
    }
}
