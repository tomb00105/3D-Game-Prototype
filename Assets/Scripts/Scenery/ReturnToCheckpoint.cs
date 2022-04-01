using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToCheckpoint : MonoBehaviour
{
    public GameObject player;
    public LevelManager levelManager;

    
    private void OnTriggerEnter(Collider other)
    {
        levelManager.LivesRemaining--;
        if (levelManager.LivesRemaining > 0)
        {
            player.transform.position = levelManager.checkpoints[levelManager.currentCheckPoint].transform.position + new Vector3(-2, 0.5f, 0);
            player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
