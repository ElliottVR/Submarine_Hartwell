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

    private GameObject grabbedBarrel;

    public AudioSource ClawSound;

    private void Update()
    {
        if (canGrab && Input.GetKeyDown(KeyCode.Space))
        {
            StartClawRetrieveAnim();
        }

        Ray ray = new Ray(transform.position, -transform.right);
        RaycastHit hit;
        //Debug.DrawRay(transform.position, -transform.right * 10f, Color.green);
        if (Physics.Raycast(ray, out hit, 5f))
        {
           
            if (hit.collider.CompareTag("Barrel"))
            {
                canGrab = true;
                grabbedBarrel = hit.collider.gameObject;
                Debug.DrawRay(transform.position, -transform.right * 5f, Color.red);
            }
        }

        else if (canGrab == false && Input.GetKeyDown(KeyCode.Space))
        {

            if (!clawRetrieveAnim.isPlaying)
                clawRetrieveAnim.Play("Claw Retrieve");
        }

        Debug.Log("canGrab = " + canGrab);
    }


    private void StartClawRetrieveAnim()
    {
        clawRetrieveAnim.Play("Claw Retrieve");
        Invoke("StartClawRetractAnim", clawRetrieveAnim.clip.length);
    }

    private void StartClawRetractAnim()
    {
        barrelInClaw.SetActive(true);
        clawRetractAnim.Play("Claw Retract");
        StartCoroutine("SoundWait");
        Destroy(grabbedBarrel);
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

    IEnumerable SoundWait()
    {
        yield return new WaitForSeconds(2);
        if (!ClawSound.isPlaying)
        {
            ClawSound.Play();
        }
    }
}
