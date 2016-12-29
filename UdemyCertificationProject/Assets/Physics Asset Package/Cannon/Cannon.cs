using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Cannon : MonoBehaviour {

    public float thrust = 500;
    public Transform muzzle;
    public Transform fireVFXOffset;
    public GameObject projectile;
    public float rateOfFire = 1.0f;
    public AudioClip fireSFX;
    public GameObject fireVFX;
    public float vfxScale = 5.0f;

    private AudioSource audioSource;
    private float firingTimer = 0.0f;
    private bool bCanFire = true;
    [SerializeField]
    private Vector3 firingImpulse = Vector3.zero;
    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        firingTimer = rateOfFire;
        audioSource = GetComponent<AudioSource>();
        rb = transform.root.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        firingTimer -= Time.deltaTime;

        if (firingTimer <= 0.0f)
            bCanFire = true;

        if (Input.GetButton("Fire1") && bCanFire)
        {
            StartCoroutine("Fire");
        }
	}

    IEnumerator Fire()
    {
        firingTimer = rateOfFire;
        bCanFire = false;
        if (fireVFX)
        {
            GameObject VFX = Instantiate(fireVFX, fireVFXOffset.position, Quaternion.identity);
            VFX.transform.localScale *= vfxScale;
            Destroy(VFX, 1.0f);
        }
        if (fireSFX)
            audioSource.PlayOneShot(fireSFX);

        CameraShake shake = Camera.main.GetComponent<CameraShake>();
        shake.StartShake();

        yield return new WaitForSeconds(0.2f);

        GameObject newProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation);
        newProjectile.GetComponent<Rigidbody>().AddForce(muzzle.forward * thrust);
        if (rb)
            rb.AddForce(firingImpulse, ForceMode.Impulse);

        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        /*
        var rb = other.GetComponent<Rigidbody>();
        rb.AddForce(muzzle.transform.forward * thrust);
        */
    }

}
