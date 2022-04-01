using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager;

    [SerializeField]
    GameObject menuPanel;

    [SerializeField]
    GameObject gameOverPanel;

    [SerializeField]
    GameObject levelCompletePanel;

    [SerializeField]
    GameObject statsPanel;

    private void Start()
    {
        levelManager.OnLivesRemainingChange += OnLivesRemainingChangeHandler;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            if (!gameOverPanel.activeInHierarchy && !levelCompletePanel.activeInHierarchy)
            {
                if (!menuPanel.activeInHierarchy)
                {
                    MenuPanelChange(true, 0);
                }
                else if (levelManager.LevelStarted)
                {
                    MenuPanelChange(false, 1);
                }
            }
        }
    }

    private void OnLivesRemainingChangeHandler(int newVal)
    {
        if (newVal == 0)
        {
            levelManager.GameOver();
            gameOverPanel.SetActive(true);
        }
    }

    void MenuPanelChange(bool active, float timeScale)
    {
        levelManager.IsPaused = active;
        Time.timeScale = timeScale;
        menuPanel.SetActive(active);
    }

    public void GameOverPanelChange()
    {
        gameOverPanel.SetActive(true);
    }

    public void LevelCompletePanelChange()
    {
        levelCompletePanel.GetComponent<LevelCompletePanel>().SetFinalValues();
        levelCompletePanel.SetActive(true);
        statsPanel.SetActive(false);
    }
}
