using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)]
    float rotateSpeedX = 0f, rotateSpeedY = 0f, rotateSpeedZ = 0f;

    private void Update()
    {
        transform.Rotate(rotateSpeedX * Time.deltaTime, rotateSpeedY * Time.deltaTime, rotateSpeedZ * Time.deltaTime);
    }
}
