using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance : MonoBehaviour
{
    public static GameInstance _instance;

    void Awake()
    {
        if (_instance != null)
            GameObject.Destroy(_instance);
        else
            _instance = this;

        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start ()
    {

        if (!Cursor.visible)
            Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainMenu()
    {
       Application.LoadLevel("Main");
    }

    public void CannonLevel()
    {
        Application.LoadLevel("Physics");
    }
}
