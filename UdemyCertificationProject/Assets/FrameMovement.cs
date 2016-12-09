using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameMovement : MonoBehaviour {

    public Transform[] frontWheels;
    public Transform[] rearWheels;
    private List<Transform> allWheels = new List<Transform>();
    public float rotationSpeed = 2.0f;
    private float sensitivity = 0.19f;
    private bool bIsInverted = true;
    private bool bCanMove = false;

    private float turnRotationAmount;
    private float moveRotationAmount;

	// Use this for initialization
	void Start ()
    {
        GrabAllWheels();
        Cursor.lockState = CursorLockMode.Locked;
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
}
