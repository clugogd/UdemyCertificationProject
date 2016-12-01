using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(CharacterController))]
public class ThirdPersonController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 5.0f;

    [SerializeField]
    private float gravity = 20.0f;

    [SerializeField]
    private float jumpSpeed = 8.0f;

    [SerializeField]
    private AudioClip walkSFX;

    private float yVelocity = 0.0f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movementSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
