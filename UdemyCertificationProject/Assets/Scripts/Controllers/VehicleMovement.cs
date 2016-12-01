using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class VehicleMovement : MonoBehaviour {

    [SerializeField]
    protected float topSpeed = 5.0f;

    [SerializeField]
    protected float acceleration = 1.0f;

    [SerializeField]
    protected float torque = 1.0f;

    [SerializeField]
    protected float drag = 0.1f;

    [SerializeField]
    protected float turnAngleABS = 30.0f;

    [SerializeField]
    protected List<GameObject> wheels;

    protected bool isGrounded = true;
    protected bool isFlippedOver = false;
    protected bool isInAir = false;

    protected Rigidbody rb;
    protected WheelCollider[] colliders;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    protected void GetAllWheelsColliders()
    {
        wheels = new List<GameObject>();
        colliders = GetComponentsInChildren<WheelCollider>();
        foreach (WheelCollider wheel in colliders)
            wheels.Add(wheel.gameObject);
    }

    protected void Grounded()
    {
        foreach (GameObject wheel in wheels)
        {
            Ray groundRay = new Ray(wheel.transform.position, -transform.up);
            RaycastHit hitInfo;
            int hitCount = 0;
            if (Physics.Raycast(groundRay, out hitInfo, 100.0f))
            {
                hitCount++;
            }
            Debug.DrawRay(transform.position, groundRay.direction, Color.red);

            if (hitCount > 3)
                isGrounded = false;
        }
    }
}
