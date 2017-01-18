using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform spawnPoint;

	// Use this for initialization
	void Start ()
    {
        if (!GameObject.Find("GameInstance"))
        {
            Debug.LogWarning("GameInstance was not found. Using test spawning.");
        }

        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject newPlayer = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
            newPlayer.tag = "Player";
            Camera.main.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
