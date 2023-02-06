using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClawController : MonoBehaviour
{
    public Animation clawRetrieveAnim;
    public Animation clawRetractAnim;
    public GameObject barrelInClaw;

    private bool canGrab = false;

    public int barrelsNeeded = 5;
    public int barrelsCollected = 0;

    private void Update()
    {
        if (canGrab && Input.GetKeyDown(KeyCode.Space))
        {
            StartClawRetrieveAnim();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrel"))
        {
            canGrab = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Barrel"))
        {
            canGrab = false;
        }
    }

    private void StartClawRetrieveAnim()
    {
        clawRetrieveAnim.Play();
        Invoke("StartClawRetractAnim", clawRetrieveAnim.clip.length);
    }

    private void StartClawRetractAnim()
    {
        barrelInClaw.SetActive(true);
        clawRetractAnim.Play();
        barrelsCollected++;
        if (barrelsCollected >= barrelsNeeded)
        {
            if (SceneManager.GetActiveScene().name == "Submarine1")
            {
                SceneManager.LoadScene("Submarine2");
            }
            else if (SceneManager.GetActiveScene().name == "Submarine2")
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }
}
