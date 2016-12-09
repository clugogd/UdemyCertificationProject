using UnityEngine;
using System.Collections;


[RequireComponent(typeof(AudioSource))]
public class GoalScoring : MonoBehaviour
{
    public Highlighter highlighter;
    public AudioClip scoringSFX;
    public GameObject scoringVFX;
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        print("Goal Scored! <" + other.name + ">");
        Destroy(other.gameObject);

        audioSource.PlayOneShot(scoringSFX);
        Destroy(Instantiate(scoringVFX, transform.position, Quaternion.identity),1.0f);

        if (highlighter)
        {
            highlighter.Highlight();
            yield return null;
        }
        else
        {
            GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(1.0f);
            GetComponent<MeshRenderer>().enabled = false;
        }
   }
}