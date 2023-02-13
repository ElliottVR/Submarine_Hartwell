using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSound : MonoBehaviour
{
    public GameObject submarine;
    public AudioSource audioSource;
    public float maxDistance = 50.0f;
    public float minDistance = 10.0f;
    public float pulseInterval = 2.0f;
    public float volume = 1.0f;

    private float timeSinceLastPulse = 0.0f;
    private bool collected = false;

    private void Update()
    {
        if (!collected)
        {
            float distance = Vector3.Distance(submarine.transform.position, transform.position);
            float normalizedDistance = Mathf.InverseLerp(minDistance, maxDistance, distance);
            float pulseIntervalMod = Mathf.Lerp(0.1f, pulseInterval, normalizedDistance);

            timeSinceLastPulse += Time.deltaTime;
            if (timeSinceLastPulse >= pulseIntervalMod)
            {
                audioSource.Play();
                timeSinceLastPulse = 0.0f;
            }

            audioSource.volume = volume * (1.0f - normalizedDistance);
        }
    }

    public void CollectBarrel()
    {
        collected = true;
        audioSource.Stop();
        audioSource.volume = 0.0f;
    }
}
