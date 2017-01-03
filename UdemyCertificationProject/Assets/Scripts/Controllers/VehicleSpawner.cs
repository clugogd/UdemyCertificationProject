using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] vehicles;

    [SerializeField]
    private float spawnRate = 3.0f;
    [SerializeField]
    private float spawnDelay = 0.5f;

    [SerializeField]
    private Transform target;

    delegate void MyDelegate();
    MyDelegate myDelegate;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("SpawnObject", spawnDelay, spawnRate);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void SpawnObject()
    {
        if (vehicles.Length > 0)
        {
            GameObject vehicle = Instantiate(vehicles[Random.Range(0, vehicles.Length)], transform.position, transform.rotation);
            vehicle.GetComponent<TrafficVehicle>().SetTarget(target);
        }
    }
}
