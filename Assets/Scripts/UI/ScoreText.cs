using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager;

    TextMeshProUGUI textField;

    private void Awake()
    {
        textField = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        textField.text = "Score: " + levelManager.currentScore.ToString();
    }
}
