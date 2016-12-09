using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float intensity = 5.0f;
    public float duration = 1.0f;
    public float delay = 0.1f;

    private float currentDuration = 0.0f;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isShaking = false;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    public void StartShake()
    {
        originalPosition = transform.localPosition;
        originalRotation = transform.rotation;
        StartCoroutine("Shake");
    }

    public IEnumerator Shake()
    {
        yield return new WaitForSeconds(delay);

        if (!isShaking)
        {
            //  Do the shaking
            isShaking = true;

            currentDuration = duration;
            while (currentDuration > 0.0f)
            {
                //  translation shake
                //transform.localPosition = originalPosition + Random.insideUnitSphere * currentDuration;

                // rotation shake
                transform.rotation = new Quaternion(originalRotation.x + Random.Range(-currentDuration, currentDuration) * .2f,
                                                    originalRotation.y + Random.Range(-currentDuration, currentDuration) * .2f,
                                                    originalRotation.z + Random.Range(-currentDuration, currentDuration) * .2f,
                                                    originalRotation.w + Random.Range(-currentDuration, currentDuration) * .2f);

                currentDuration -= Time.deltaTime;
                yield return null;
            }

            isShaking = false;
        }
    }
}
