using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed = 1f;
    public float minDistance = 1f;
    public GameObject submarine;

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, submarine.transform.position);

        if (distance < minDistance)
        {
            Vector3 direction = new Vector3((transform.position.x - submarine.transform.position.x), 0, (transform.position.z - submarine.transform.position.z));
            direction = direction.normalized;
            Vector3 target = transform.position + direction * speed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime);
        }

        //Debug.Log("Fish Distance: " + distance);
    }

   
}
