using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public float speed = 3.0f;
    public float thrust = 3.0f;
    public Rigidbody rb;
    public Vector3 movement;
    public Vector3 rotation;
    private Vector2 inputDirection;
    //private Vector3 direction;

    public float movementSpeed = 15;
    //public Vector3 rotationSpeed = new Vector3(0, 40, 0);

    public float rotationSpeed;



    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(0, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rotation = new Vector2(0, Input.GetAxis("Rotate"));
        //rotation = new Vector2(Input.GetAxis("Rotate"), 0);

        //inputDirection = rotation.normalized;
        movement.Normalize();

        Debug.Log(rb.velocity.magnitude);
        //Debug.Log(rb.velocity);

        //direction = rb.velocity.normalized;

        /*
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            rotate = true;
            rotX = Input.GetAxis("Rotate") * strength;
        }
        */
    }

    void FixedUpdate ()
    {
        moveCharacter(movement);


        //Quaternion deltaRotation = Quaternion.Euler(inputDirection.x * rotationSpeed * Time.deltaTime);
        //rb.MoveRotation(rb.rotation * deltaRotation);
        //rb.MovePosition(rb.position + transform.up * movementSpeed * inputDirection.y * Time.deltaTime);

        //float translate = Input.GetAxis("Rotate");
        //transform.forward = new Vector3(translate, 0, 0);
        //transform.Translate(Vector3.forward * Mathf.Abs(translate) * 2 * Time.deltaTime);

        Quaternion deltaRotation = Quaternion.Euler(rotation * 10 * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);

        //rb.velocity = transform.rotation * rotation * rotationSpeed;

        //rb.AddRelativeTorque(rotation, ForceMode.Impulse);

        /*
        if (rotate)
        {
            rb.AddTorque(rotY, -rotX, 0);
        }
        */

        //Quaternion deltaRotation = Quaternion.Euler(movement * 10 * Time.fixedDeltaTime);
        //rb.MoveRotation(rb.rotation * deltaRotation);

    }

    void moveCharacter (Vector3 direction)
    {
        //rb.MovePosition((Vector2)transform.position + (-direction * speed * Time.deltaTime));

        if (rb.velocity.magnitude <= 8.0f)
        {
            Vector3 dir = transform.TransformDirection(movement);
            //Vector3 pos = transform.position + dir;
            rb.AddForce(dir * speed);
            //rb.AddForce(direction * speed);
        }


    }
}
