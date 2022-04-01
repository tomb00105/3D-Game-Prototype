using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeText : MonoBehaviour
{
    [SerializeField]
    LevelManager levelManager;

    TextMeshProUGUI textField;

    private void Awake()
    {
        textField = GetComponent<TextMeshProUGUI>();
        textField.text = "Time: " + levelManager.timeToCompleteLevel;
    }
    void Update()
    {
        textField.text = "Time: " + Mathf.RoundToInt(levelManager.timeRemaining).ToString();
    }
}
