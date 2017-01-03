using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ExplodeOnContact : MonoBehaviour {

    [SerializeField]
    private GameObject VFX;
    [SerializeField]
    private AudioClip SFX;
    private AudioSource AS;

	// Use this for initialization
	void Start ()
    {
        AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ScoringTrigger")
            return;

        Destroy(Instantiate(VFX,transform.position,Quaternion.identity), 1.0f);
        AS.PlayOneShot(SFX);
        Camera.main.GetComponent<CameraShake>().StartShake();
        Destroy(this);
    }
}
