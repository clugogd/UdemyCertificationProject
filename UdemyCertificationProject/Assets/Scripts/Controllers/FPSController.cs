using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioListener))]
public class FPSController : MonoBehaviour {

    [SerializeField]
    private float movementSpeed = 6.0f;
    [SerializeField]
    private float jumpSpeed = 8.0f;
    [SerializeField]
    private float gravity = 20.0f;
    [SerializeField]
    private float turnSpeed = 20.0f;

    private float deadZone = 0.019f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

	// Use this for initialization
	void Start ()
    {
        Camera.main.GetComponent<AudioListener>().enabled = false;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float moveForward = Input.GetAxis("Vertical");
        float moveStrafe = Input.GetAxis("Horizontal");

        float yaw = 0.0f;
        if (Mathf.Abs(Input.GetAxis("Mouse X")) >  deadZone)
            yaw = Input.GetAxis("Mouse X");
        else if (Mathf.Abs(Input.GetAxis("RSHorizontal")) > deadZone)
            yaw = Input.GetAxis("RSHorizontal");
        yaw = yaw * Time.deltaTime * turnSpeed;

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(moveStrafe, 0.0f, moveForward);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movementSpeed;

            if( Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        transform.Rotate(Vector3.up * yaw, Space.World);
        controller.Move(moveDirection * Time.deltaTime);
	}
}
