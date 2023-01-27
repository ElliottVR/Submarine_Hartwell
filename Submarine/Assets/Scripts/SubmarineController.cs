using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SubmarineController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotateSpeed = 50.0f;
    public float moveSpeed = 10f;

    public float riseSpeed = 2f;
    public float sinkSpeed = 2f;

    public float maxDepth = 10f;
    public float minDepth = -10f;

    private float currentDepth;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * moveSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentDepth = transform.position.y;
            if (currentDepth < maxDepth)
                transform.Translate(Vector3.up * riseSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            currentDepth = transform.position.y;
            if (currentDepth > minDepth)
                transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }

}

