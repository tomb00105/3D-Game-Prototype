using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveVal;
    public Vector2 lookVal;
    public float moveSpeed = 1f;
    void OnMove(InputValue value)
    {
        moveVal = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        lookVal = value.Get<Vector2>();
    }
    void Update()
    {
        transform.Translate(new Vector3(moveVal.x, 0, moveVal.y) * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, lookVal.x, 0));
        transform.Find("Main Camera").
    }
    void LateUpdate()
    {
        offsetX = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.up) * offsetX;
        offsetY = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * offsetY;
        transform.position = player.position + offsetX;
        transform.LookAt(player.position);
    }
}
