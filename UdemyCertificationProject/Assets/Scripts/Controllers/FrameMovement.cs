using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameMovement : MonoBehaviour {

    public Transform[] frontWheels;
    public Transform[] rearWheels;
    private List<Transform> allWheels = new List<Transform>();
    public float rotationSpeed = 2.0f;
    private float sensitivity = 0.19f;
    [SerializeField]
    private bool bIsInverted = true;
    [SerializeField]
    private bool bCanMove = false;
 
    private float turnRotationAmount;
    private float moveRotationAmount;
    private Quaternion originalRotation;
    private Vector3 originalPosition;

	// Use this for initialization
	void Start ()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        Cursor.lockState = CursorLockMode.Locked;

        GrabAllWheels();
    }

    // Update is called once per frame
    void Update()
    {
        turnRotationAmount = Input.GetAxis("Mouse X");
        if (Mathf.Abs(turnRotationAmount) - sensitivity > 0.0f)
        {
            transform.Rotate(transform.up * turnRotationAmount);
            turnRotationAmount *= rotationSpeed;

            if (turnRotationAmount != 0.0f)
                Turn(turnRotationAmount);
        }

        if (bCanMove)
        {
            moveRotationAmount = Input.GetAxis("Vertical");
            if (moveRotationAmount < 0.0f)
                Forward(moveRotationAmount);
            if (moveRotationAmount > 0.0f)
                Forward(moveRotationAmount);

            transform.Translate(transform.forward * moveRotationAmount * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
            Camera.main.GetComponent<CameraShake>().Reset();
        }
    }

    void GrabAllWheels()
    {
        foreach (Transform wheel in frontWheels)
            allWheels.Add(wheel);
        foreach (Transform wheel in rearWheels)
            allWheels.Add(wheel);
    }
    void Turn(float rotationAmount)
    {
        if (rotationAmount < 0)
        {
            frontWheels[0].Rotate(transform.up * rotationAmount);
            rearWheels[0].Rotate(transform.up * rotationAmount);
            frontWheels[1].Rotate(transform.up * -rotationAmount);
            rearWheels[1].Rotate(transform.up * -rotationAmount);
        }
        else if (rotationAmount > 0)
        {
            frontWheels[0].Rotate(transform.up * -rotationAmount);
            rearWheels[0].Rotate(transform.up * -rotationAmount);
            frontWheels[1].Rotate(transform.up * rotationAmount);
            rearWheels[1].Rotate(transform.up * rotationAmount);
        }
    }
    void Forward(float rotationAmount)
    {
        if (bIsInverted)
            rotationAmount *= -1;

        foreach (Transform wheel in allWheels)
            wheel.Rotate(transform.up * rotationAmount);
    }

    void Reset()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
