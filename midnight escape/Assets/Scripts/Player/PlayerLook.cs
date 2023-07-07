using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 60f;
    public float ySensitivity = 60f;

    public void ProcessLook(Vector2 input)
    {
        if (Input.GetMouseButton(0))
        {
            float mouseX = -input.x;
            float mouseY = -input.y;
            //calcaulatre camera rortation for look up and dowwn
            xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
            xRotation = Mathf.Clamp(xRotation, -80, 80f);
            //apply this to our camera trasnsform
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            //rootate player to look left and right
            transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
        }
    }
}
