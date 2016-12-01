using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    public enum CONTROLTYPE {  PLAYER = 0, AI, NOTCONTROLLED }

    [SerializeField]
    private CONTROLTYPE currentType = CONTROLTYPE.PLAYER;

	// Use this for initialization
	void Start ()
    {
        EnableMovementType();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void EnableMovementType()
    {
        if (currentType == CONTROLTYPE.PLAYER)
            gameObject.AddComponent<VehicleMovementPlayer>();
        else if (currentType == CONTROLTYPE.AI)
            gameObject.AddComponent<VehicleMovementAI>();
    }
}
