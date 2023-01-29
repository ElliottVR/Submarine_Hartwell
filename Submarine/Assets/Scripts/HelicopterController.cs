using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterController : MonoBehaviour
{
    public float speed = 10f; // The speed at which the helicopter moves
    public float xMin = -5f; // The minimum x coordinate the helicopter can be at
    public float xMax = 5f; // The maximum x coordinate the helicopter can be at
    public float zMin = -5f; // The minimum z coordinate the helicopter can be at
    public float zMax = 5f; // The maximum z coordinate the helicopter can be at
    public float windSpeed = 1f; // The speed at which the wind is blowing
    public GameObject submarinePrefab; // The submarine prefab to be instantiated when the player drops it
    public float waterHeight = -5f; // The y coordinate at which the water is located

    private GameObject _submarine; // The submarine instance that's currently attached to the helicopter
    private bool _isSubmarineDropped = false; // A boolean variable to keep track of whether the submarine has been dropped or not

    public DropTarget dropTarget;

    void Start()
    {
        // Instantiate the submarine at the bottom of the helicopter and make it a child
        _submarine = Instantiate(submarinePrefab, transform.position + new Vector3(0f, -1f, 0f), Quaternion.Euler(0f, 0f, 90f));
        _submarine.transform.parent = transform;
    }

    void Update()
    {
        float xInput = 0f;
        if (Input.GetKey(KeyCode.D))
            xInput = 1f;
        else if (Input.GetKey(KeyCode.A))
            xInput = -1f;

        float zInput = 0f;
        if (Input.GetKey(KeyCode.W))
            zInput = 1f;
        else if (Input.GetKey(KeyCode.S))
            zInput = -1f;

        // Add random movement to simulate wind
        xInput += Random.Range(-windSpeed, windSpeed);
        zInput += Random.Range(-windSpeed, windSpeed);

        // Update the helicopter's position based on the input
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + xInput * speed * Time.deltaTime, xMin, xMax),
            transform.position.y,
            Mathf.Clamp(transform.position.z + zInput * speed * Time.deltaTime, zMin, zMax)
        );

        // Check if the player pressed the "Space" key
        if (Input.GetKeyDown(KeyCode.Space) && !_isSubmarineDropped)
        {
            _isSubmarineDropped = true;
            // Detach the submarine from the helicopter
            _submarine.transform.parent = null;
            // Add some rigid body component to the submarine so that it can fall with gravity
            _submarine.AddComponent<Rigidbody>();
            StartCoroutine(WaitForDrop());
        }
        // Check if the submarine has hit the water
        if (_submarine.transform.position.y <= waterHeight)
        {
            // Disable the rigid body component so that the submarine stops falling
            _submarine.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    IEnumerator WaitForDrop()
    {
        yield return new WaitForSeconds(2f);
        dropTarget.SubmarineDropped();
    }
}

