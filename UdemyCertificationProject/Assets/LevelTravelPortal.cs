using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTravelPortal : MonoBehaviour {

    [SerializeField]
    private string levelToTravelToName = "Main";
    [SerializeField]
    private int levelToTravelToIndex = -1;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (levelToTravelToIndex < 0)
                TravelToLevel(levelToTravelToName);
            else
                TravelToLevel(levelToTravelToIndex);
        }
    }

    void TravelToLevel(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
    void TravelToLevel(int index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
