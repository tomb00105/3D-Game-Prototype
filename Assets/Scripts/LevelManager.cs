using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    UIController uIController;

    [SerializeField]
    PlayerController playerController;

    [SerializeField, Range(0, 5)]
    int startingLives;

    [SerializeField]
    int livesRemaining;

    [Min(0f)]
    public float timeToCompleteLevel = default;

    [Min(0f)]
    public float timeRemaining;

    public int currentScore;

    [SerializeField, Min(0f)]
    float velocityScoreFactor;

    [SerializeField, Min(0f)]
    float livesScoreFactor;

    [SerializeField, Min(0f)]
    float timeScoreFactor;
    public bool LevelStarted { get; set; } = false;
    public bool IsPaused { get; set; } = true;

    public int currentCheckPoint = 0;

    public int LivesRemaining
    {
        get { return livesRemaining; }
        set
        {
            if (livesRemaining == value)
            {
                return;
            }
            livesRemaining = value;
            if (OnLivesRemainingChange != null)
            {
                OnLivesRemainingChange(livesRemaining);
            }
        }
    }

    public delegate void OnLivesRemainingChangeDelegate(int newValue);
    public event OnLivesRemainingChangeDelegate OnLivesRemainingChange;

    public List<GameObject> checkpoints = new List<GameObject>();

    private void Awake()
    {
        Time.timeScale = 0;
        IsPaused = true;
        livesRemaining = 5;
    }

    private void Start()
    {
        timeRemaining = timeToCompleteLevel;
        OnLivesRemainingChange += OnLivesRemainingChangeHandler;
    }

    private void Update()
    {
        if (LevelStarted)
        {
            timeRemaining -= Time.deltaTime;
            UpdateCurrentScore();
        }
        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            GameOver();
        }
    }

    private void OnLivesRemainingChangeHandler(int newVal)
    {
        if (newVal <= 0)
        {
            Time.timeScale = 0;
            IsPaused = true;
        }
    }

    public void UpdateCheckpoint(int triggeredCheckpoint)
    {
        if (triggeredCheckpoint > currentCheckPoint)
        {
            currentCheckPoint = triggeredCheckpoint;
        }
    }

    private void UpdateCurrentScore()
    {
        float timeScore = timeRemaining * timeScoreFactor;
        float velocityScore = playerController.averageVelocity * velocityScoreFactor;
        float livesScore = livesRemaining * livesScoreFactor;
        currentScore = Mathf.RoundToInt(timeScore + velocityScore + livesScore);
    }

    public void SetTimeScale(int value)
    {
        Time.timeScale = value;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelComplete()
    {
        Time.timeScale = 0;
        IsPaused = true;
        uIController.LevelCompletePanelChange();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        IsPaused = true;
        uIController.GameOverPanelChange();
    }

}
