using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(NavMeshAgent))]
public class TopDownController : MonoBehaviour
{
    [SerializeField]
    private Camera topDownCamera;

    [SerializeField]
    private ParticleSystem clickVFX;
    [SerializeField]
    private AudioClip clickSFX;

    private NavMeshAgent agent;
    private Rigidbody rb;
    private AudioSource audioSource;

    private Transform destination;

    // Use this for initialization
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();    		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Ray clickRay = topDownCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit clickHit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(clickRay, out clickHit, 100.0f))
            {
                agent.SetDestination(clickHit.point);
                Destroy(Instantiate(clickVFX, clickHit.point, Quaternion.identity), 1.0f);
                audioSource.PlayOneShot(clickSFX);
            }
        }
	}
}
