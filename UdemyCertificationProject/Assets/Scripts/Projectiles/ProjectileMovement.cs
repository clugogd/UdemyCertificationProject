using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class ProjectileMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 5.0f;

    [SerializeField]
    private float lifeTime = 2.0f;

    [SerializeField]
    private TrailRenderer trail;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        trail.enabled = true;
        Destroy(gameObject, lifeTime);	
	}

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection = transform.forward * movementSpeed;
        transform.position = transform.position + moveDirection * Time.deltaTime;
    }
}
