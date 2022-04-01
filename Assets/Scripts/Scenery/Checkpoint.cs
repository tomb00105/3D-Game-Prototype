using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        levelManager.UpdateCheckpoint(levelManager.checkpoints.IndexOf(gameObject));
        if (levelManager.checkpoints[levelManager.checkpoints.Count - 1] == gameObject)
        {
            levelManager.LevelComplete();
        }
    }
}
