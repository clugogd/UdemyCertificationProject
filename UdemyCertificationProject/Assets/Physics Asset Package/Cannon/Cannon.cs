using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Cannon : MonoBehaviour {

    public float thrust = 500;
    public Transform muzzle;
    public GameObject projectile;
    public float rateOfFire = 1.0f;
    public AudioClip fireSFX;
    public GameObject fireVFX;

    private AudioSource audioSource;
    private float firingTimer = 0.0f;
    private bool bCanFire = true;

    // Use this for initialization
    void Start ()
    {
        firingTimer = rateOfFire;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        firingTimer -= Time.deltaTime;

        if (firingTimer <= 0.0f)
            bCanFire = true;

        if (Input.GetButton("Fire1") && bCanFire)
        {
            firingTimer = rateOfFire;
            bCanFire = false;
            GameObject newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * thrust);
            if( fireVFX )
                Destroy(Instantiate(fireVFX, muzzle.position, Quaternion.identity),0.5f);
            if( fireSFX)
                audioSource.PlayOneShot(fireSFX);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        /*
        var rb = other.GetComponent<Rigidbody>();
        rb.AddForce(muzzle.transform.forward * thrust);
        */
    }

}
