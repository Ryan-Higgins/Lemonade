using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 5;
    Vector3 pos;
    public Vector2 panLimit;

    private void Update()
    {
        pos = transform.position;
        pos.y += Input.GetAxis("Vertical") * panSpeed * Time.deltaTime;
        pos.x += Input.GetAxis("Horizontal") * panSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);
        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        transform.position = pos;
    }
}
