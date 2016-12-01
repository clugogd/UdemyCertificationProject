using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovementAI : VehicleMovement {

    private Transform target;
    private float followDistance = 10.0f;

	// Use this for initialization
	void Start ()
    {
        topSpeed = 5.0f;
        if (!target)
            target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if( Vector3.Distance(target.position, transform.position) > followDistance )
        {
            transform.LookAt(target);
            transform.Translate(transform.forward * topSpeed * Time.deltaTime, Space.World);
        }	
	}
}
