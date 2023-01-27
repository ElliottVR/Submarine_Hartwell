using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCameraController : MonoBehaviour
{
    public float sensitivity = 5.0f;
    public float limitX = 80.0f;
    public float limitY = 80.0f;
    //public Vector3 startRotation = new Vector3(0, 0, 0);

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        //rotationX = startRotation.y;
        //rotationY = startRotation.x;
        //transform.localEulerAngles = new Vector3(-startRotation.x, -startRotation.y, -startRotation.z);
        transform.LookAt(transform.position + transform.forward);
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180f, transform.rotation.eulerAngles.z);
        transform.Rotate(0f, 180f, 0f);
    }

    void Update()
    {
        rotationX += Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;

        rotationX = ClampAngle(rotationX, -limitX, limitX);
        rotationY = ClampAngle(rotationY, -limitY, limitY);

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0.0f);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F) angle += 360F;
        if (angle > 360F) angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
