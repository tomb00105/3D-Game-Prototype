using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesText : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager;
    
    TextMeshProUGUI textField;

    private void Awake()
    {
        textField = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        textField.text = "Lives: " + levelManager.LivesRemaining.ToString();
        levelManager.OnLivesRemainingChange += OnLivesRemainingChangeHandler;
    }

    private void OnLivesRemainingChangeHandler(int newVal)
    {
        textField.text = "Lives: " + newVal.ToString();
    }
}
