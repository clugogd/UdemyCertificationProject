using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {

    public enum CAMERAMODE { FPS = 0, THIRDPERSON, TOPDOWN, INVALID }
    private CAMERAMODE activeCamera = CAMERAMODE.FPS;
    private Vector3 defaultOffset = new Vector3(0.0f, 5.0f, -10.0f);

    [SerializeField]
    private Transform[] cameraList;

    [SerializeField]
    private Camera myCamera;

	// Use this for initialization
	void Start ()
    {
        EnableSpecificCamera(activeCamera);
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if( Input.GetKeyDown(KeyCode.Alpha1) )
        {
            EnableSpecificCamera(CAMERAMODE.FPS);
        }	
        else if( Input.GetKeyDown(KeyCode.Alpha2) )
        {
            EnableSpecificCamera(CAMERAMODE.THIRDPERSON);
        }
	}

    void EnableSpecificCamera(CAMERAMODE mode)
    {
        if (mode >= CAMERAMODE.INVALID || mode < CAMERAMODE.FPS)
        {
            myCamera.transform.position = transform.position + defaultOffset;
            myCamera.transform.rotation = transform.rotation;
        }
        else
        {
            myCamera.transform.position = cameraList[(int)mode].position;
        }
    }
}
