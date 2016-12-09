using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMovement : MonoBehaviour {

    public float speed = 5.0f;
    public float minAngle = 0.0f;
    public float maxAngle = 90.0f;

    private float pitch = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetAxis("Mouse Y") != 0.0f)
        {
            pitch += Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, minAngle, maxAngle);
            transform.localEulerAngles = new Vector3(-pitch, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
	}
}
