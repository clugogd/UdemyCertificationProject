using UnityEngine;
using System.Collections;

public class GoalScoring : MonoBehaviour
{
    public Highlighter highlighter;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        print("Goal Scored! <" + other.name + ">");
        Destroy(other.gameObject);

        GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(1.0f);
        GetComponent<MeshRenderer>().enabled = false;

        if (highlighter)
        {
            highlighter.Highlight();
        }
    }
}