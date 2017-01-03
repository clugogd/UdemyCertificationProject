using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GoalScoring : MonoBehaviour
{
    public Highlighter highlighter;
    public AudioClip scoringSFX;
    public GameObject scoringVFX;
    private AudioSource audioSource;
    public Text scoreText;
    public Text scoreNotification;

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
        GameObject scoringeffect = Instantiate(scoringVFX,transform.position,transform.rotation);
        scoringeffect.transform.localScale.Set(50.0f, 50.0f, 50.0f);
        Destroy(scoringeffect,1.0f);

        scoreNotification.gameObject.SetActive(true);
        scoreNotification.gameObject.GetComponentInParent<Image>().enabled = true;

        if (highlighter)
        {
            highlighter.Highlight();
            GameState._instance.AddScore(1);

            yield return new WaitForSeconds(0.5f);
            scoreNotification.gameObject.SetActive(false);
            scoreNotification.gameObject.GetComponentInParent<Image>().enabled = false;
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