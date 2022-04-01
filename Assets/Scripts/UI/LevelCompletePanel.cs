using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCompletePanel : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager;

    [SerializeField]
    PlayerController playerController;

    [SerializeField]
    TextMeshProUGUI finalTimeRemainingTextField;

    [SerializeField]
    TextMeshProUGUI finalLivesRemainingTextField;

    [SerializeField]
    TextMeshProUGUI finalAverageVelocityTextField;

    [SerializeField]
    TextMeshProUGUI finalScoreTextField;

    public void SetFinalValues()
    {
        finalTimeRemainingTextField.text = "Time: " + Mathf.RoundToInt(levelManager.timeRemaining).ToString();
        finalLivesRemainingTextField.text = "Lives: " + levelManager.LivesRemaining.ToString();
        finalAverageVelocityTextField.text = "Average Velocity: " + Mathf.RoundToInt(playerController.averageVelocity / 2).ToString();
        finalScoreTextField.text = "Final Score: " + levelManager.currentScore.ToString();
    }
}
