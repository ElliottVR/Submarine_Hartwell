using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClawController : MonoBehaviour
{
    public Animation clawAnim;
    //public Animation clawRetractAnim;
    public GameObject barrelInClaw;

    private bool canGrab = false;

    public int barrelsNeeded = 5;
    public int barrelsCollected = 0;

    private GameObject grabbedBarrel;

    public AudioSource ClawSound;
    public AudioSource dialogueBarrel;

    public Text barrelsRemaining;
    private int barrelsRemainingNumber;
    private string barrelsRemainingString;

    void Start()
    {
        barrelsRemainingNumber = barrelsNeeded - barrelsCollected;
        barrelsRemainingString = barrelsRemainingNumber.ToString();

        barrelsRemaining.text = barrelsRemainingString;
    }

    void Update()
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



        /*
        else if (canGrab == false && Input.GetKeyDown(KeyCode.Space))
        {

            if (!clawRetrieveAnim.isPlaying)
                clawRetrieveAnim.Play("Claw Retrieve");
        }
        */

        //Debug.Log("canGrab = " + canGrab);
    }


    void StartClawRetrieveAnim()
    {
        //clawRetrieveAnim.Play("Claw Retrieve");
        if (!dialogueBarrel.isPlaying)
        {
            dialogueBarrel.Play();
        }
        //Invoke("StartClawRetractAnim", clawRetrieveAnim.clip.length);
        StartClawRetractAnim();
    }

    void StartClawRetractAnim()
    {
        Destroy(grabbedBarrel);
        canGrab = false;
        barrelInClaw.SetActive(true);
        clawAnim.Play("Claw Retract");
        barrelsCollected++;
        Debug.Log("Barrels Collected: " + barrelsCollected);
        GameVariables.barrelsCollectedTotal++;
        barrelsRemainingNumber = barrelsNeeded - barrelsCollected;
        barrelsRemainingString = barrelsRemainingNumber.ToString();
        barrelsRemaining.text = barrelsRemainingString;
        StartCoroutine(SoundWait());
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

    IEnumerator SoundWait()
    {
        yield return new WaitForSeconds(2.0f);
        //if (!ClawSound.isPlaying)
        //{
            ClawSound.Play();
        //}
       
        yield return new WaitForSeconds(4.0f);
        barrelInClaw.SetActive(false);
        GameVariables.fuelAmount = 100;
        clawAnim.Play("Replace");
        //clawRetrieveAnim.Play("Claw Open");

    }
}
