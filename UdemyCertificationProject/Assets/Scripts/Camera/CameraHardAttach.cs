using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHardAttach : MonoBehaviour {

    [SerializeField]
    private Transform objectToFollow;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private bool isFPSCamera = false;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = objectToFollow.position;
        transform.forward = objectToFollow.forward;
    }
}
