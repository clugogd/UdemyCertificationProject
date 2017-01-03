using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficVehicle : MonoBehaviour {

    private Transform destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (destination)
        {
            transform.position = Vector3.Lerp(transform.position, destination.position, Time.deltaTime);
        }	
	}

    public void SetTarget(Transform target)
    {
        destination = target;
    }
}
