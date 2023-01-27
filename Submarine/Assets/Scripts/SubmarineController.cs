using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SubmarineController : MonoBehaviour
{
    //Speed Vars
    public float speed = 10.0f;
    public float rotateSpeed = 50.0f;
    public float moveSpeed = 10f;

    //Rise and Sink Vars
    public float riseSpeed = 2f;
    public float sinkSpeed = 2f;

    //Depth Limiter Vars
    public float maxDepth = 10f;
    public float minDepth = -10f;

    //What do you think?
    private float currentDepth;

    //Fuel Vars
    public float fuelAmount = 100.000000f;
    public Slider slider;
    bool isMoving;
    public float sliderValue;

    void Update()
    {
        // Slider Value
        slider.value = fuelAmount /100;

        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * moveSpeed * Time.deltaTime, Space.World);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            isMoving = true;
            currentDepth = transform.position.y;
            if (currentDepth < maxDepth)
                transform.Translate(Vector3.up * riseSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.E))
        {
            isMoving = true;
            currentDepth = transform.position.y;
            if (currentDepth > minDepth)
                transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            isMoving = true;
        }

        //Fuel
        if (isMoving == true)
        {
            fuelAmount -= 0.01f;
        }

        if (fuelAmount < 0)
        {
            fuelAmount = 0;
        }

        if (fuelAmount > 100)
        {
            fuelAmount = 100;
        }

        else
        {
            isMoving = false;
        }

        Debug.Log("Fuel Amount: " + fuelAmount);

    }

}