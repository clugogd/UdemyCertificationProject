using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
//       Application.LoadLevel("Main");
    }

    public void CannonLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Physics");
//        Application.LoadLevel("Physics");
    }
}
