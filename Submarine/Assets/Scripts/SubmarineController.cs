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

    //Limits to scene bounds
    public float maxX = 30f;
    public float minX = -30f;
    public float maxZ = 30f;
    public float minZ = -30f;

    //Limit sub from hitting object
    public float minDistanceToObject = 5f;

    //What do you think?
    private float currentDepth;

    //Fuel Vars
    public float fuelAmount = 100.000000f;
    public Slider slider;
    bool isMoving;
    public float sliderValue;

    //Sounds
    public AudioSource collisionBig;

    void Update()
    {
        // Slider Value
        slider.value = fuelAmount /100;

        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, minDistanceToObject))
            {
                if (hit.collider != null)
                {
                    if (!collisionBig.isPlaying)
                    {
                        collisionBig.Play();
                    }
                    // stop the submarine's movement
                    return;

                }
            }

            transform.Translate(transform.forward * moveSpeed * Time.fixedDeltaTime, Space.World);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * moveSpeed * Time.fixedDeltaTime, Space.World);
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            isMoving = true;
            currentDepth = transform.position.y;
            if (currentDepth < maxDepth)
                transform.Translate(Vector3.up * riseSpeed * Time.fixedDeltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.E))
        {
            isMoving = true;
            currentDepth = transform.position.y;
            if (currentDepth > minDepth)
                transform.Translate(Vector3.down * sinkSpeed * Time.fixedDeltaTime, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -rotateSpeed * Time.fixedDeltaTime);
            //isMoving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.fixedDeltaTime);
            //isMoving = true;
        }

        //Scene Bounding Logic
        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
        if (transform.position.x < minX)
        {
            transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }
        if (transform.position.z > maxZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, maxZ);
        }
        if (transform.position.z < minZ)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, minZ);
        }

        //Fuel
        if (isMoving == true)
        {
            fuelAmount -= 2f * Time.fixedDeltaTime;
        }

        if (fuelAmount < 0f)
        {
            fuelAmount = 0f;
        }

        if (fuelAmount > 100f)
        {
            fuelAmount = 100f;
        }

        else
        {
            isMoving = false;
        }


        Debug.Log("Fuel Amount: " + fuelAmount);

    }

}