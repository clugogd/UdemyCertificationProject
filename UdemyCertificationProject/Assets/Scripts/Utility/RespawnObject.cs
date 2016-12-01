using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour {

    [SerializeField]
    private Transform respawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        //  Make sure we are applying the respawn to the root object
        //  This should either be an event or a function call to the respawn functionality
        other.gameObject.transform.root.position = respawnPoint.position;
        other.gameObject.transform.root.rotation = Quaternion.identity;
    }
}
