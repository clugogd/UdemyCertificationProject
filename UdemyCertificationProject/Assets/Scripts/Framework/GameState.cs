using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameState : MonoBehaviour {

    [SerializeField]
    private int MatchScoreLimit = 0;
    [SerializeField]
    private float MatchTimeInSeconds = 0.0f;
    [SerializeField]
    private Text timeDisplayText;
    [SerializeField]
    private Text scoreDisplayText;
    [SerializeField]
    private Text gameOverDisplay;
    [SerializeField]
    private Text victoryDisplay;

    [SerializeField]
    AudioClip victorySFX;
    [SerializeField]
    AudioClip defeatSFX;
    [SerializeField]
    AudioClip scoreSFX;

    [SerializeField]
    private int currentScore = 0;
    [SerializeField]
    private float currentMatchTime = 0.0f;
    [SerializeField]
    private bool bPaused = false;
    [SerializeField]
    private bool bGameOver = false;
    [SerializeField]
    private float transitionTime = 2.0f;

    private string displayString = "";
    public static GameState _instance;
    private int originalScoreLimit;
    private float originalTimeLimit;
    private AudioSource AS;

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
        originalScoreLimit = MatchScoreLimit;
        originalTimeLimit = MatchTimeInSeconds;
        AS = GetComponent<AudioSource>();

        Reset();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (bGameOver)
            return;
      
        CheckForGameOver();

        if (bPaused)
            return;

        currentMatchTime -= Time.deltaTime;

        UpdateTimer();
    }

    void UpdateScore()
    {
        scoreDisplayText.text = currentScore.ToString();
    }

    void UpdateTimer()
    {
        int minutes,seconds;
        minutes = (int)(currentMatchTime / 60);
        
        string secondDisplay = "";
        if (minutes == 0)
        {
            seconds = (int)(currentMatchTime % 60);
            if (seconds > 10)
            {
                secondDisplay = seconds.ToString();
                displayString = minutes.ToString() + ":" + secondDisplay;
            }
            else
            {
                float fSeconds = currentMatchTime % 60;
                secondDisplay = fSeconds.ToString("F2");
                displayString = secondDisplay;
            }            
        }
        else
            displayString = minutes.ToString() + ":" + secondDisplay;

        //Debug.Log(displayString);
        if (timeDisplayText)
        {
            if (currentMatchTime <= 0.0f)
                timeDisplayText.text = "0:0";
            else
                timeDisplayText.text = displayString;
        }
    }

    public void CheckForGameOver()
    {
        if(currentScore >= MatchScoreLimit)
        {
            victoryDisplay.gameObject.SetActive(true);
            victoryDisplay.GetComponentInParent<Image>().enabled = true;
            bGameOver = true;
            AS.PlayOneShot(victorySFX);
            Invoke("LevelUp", victorySFX.length);
            return;
        }
        if (currentMatchTime <= 0.0f)
        {
            gameOverDisplay.gameObject.SetActive(true);
            gameOverDisplay.GetComponentInParent<Image>().enabled = true;
            bGameOver = true;
            AS.PlayOneShot(defeatSFX);
            Invoke("GameOverTransition", defeatSFX.length);
            return;
        }
        bGameOver = false;
    }

    public void AddScore(int value)
    {
        if (bGameOver || bPaused)
            return;

        currentScore += value;
        AS.PlayOneShot(scoreSFX);
        UpdateScore();
    }
    public void AddTime(int value)
    {
        MatchTimeInSeconds += value;
    }
    public void IncreaseScoreLimit(int value)
    {
        MatchScoreLimit += value;
    }

    void LevelUp()
    {
        IncreaseScoreLimit(1);
        AddTime(10);
        Reset();
    }
    void GameOverTransition()
    {
        MatchTimeInSeconds = originalTimeLimit;
        MatchScoreLimit = originalScoreLimit;
        Reset();
    }

    void Reset()
    {
        currentScore = 0;
        UpdateScore();

        currentMatchTime = MatchTimeInSeconds;
        UpdateTimer();

        gameOverDisplay.gameObject.SetActive(false);
        gameOverDisplay.GetComponentInParent<Image>().enabled = false;
        victoryDisplay.gameObject.SetActive(false);
        victoryDisplay.GetComponentInParent<Image>().enabled = false;

        bGameOver = false;

        CancelInvoke("GameOverTransition");
    }

}
