using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLerp : MonoBehaviour
{
    public Vector3 endPosition = new Vector3 (0,0,0);
    private Vector3 startPosition;
    public float desiredDuration = 3f;
    private float elapsedTime;

    [SerializeField]
    private AnimationCurve curve;
    
    void Start()
    {
        startPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        float percentageComplete = elapsedTime / desiredDuration;

        transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
    }
}
