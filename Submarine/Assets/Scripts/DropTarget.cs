using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropTarget : MonoBehaviour
{
    public float xMin, xMax, zMin, zMax; // Min and max values for x and z axis
    public Text hitText; // Text to display when the player hits the target
    public Text missText; // Text to display when the player misses the target
    private bool hit;
    private bool isSubmarineDropped;


    void Start()
    {
        // Randomize starting position of the target within the given range
        float xPos = Random.Range(xMin, xMax);
        float zPos = Random.Range(zMin, zMax);
        transform.position = new Vector3(xPos, transform.position.y, zPos);
        hit = false;
        missText.gameObject.SetActive(false);
        hitText.gameObject.SetActive(false);
        isSubmarineDropped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("submarine"))
        {
            hit = true;
            hitText.gameObject.SetActive(true);
            hitText.text = "Congratulations, you hit the target!";
            StartCoroutine(WaitForSceneLoad());
        }
    }

    private void Update()
    {
        if (!hit && isSubmarineDropped == true)
        {
            missText.gameObject.SetActive(true);
            missText.text = "Try Again!";
            Invoke("ReloadScene", 2f);
        }
    }
    public void reset()
    {
        if (isSubmarineDropped == true)
        {
            hit = false;
            missText.gameObject.SetActive(false);
            hitText.gameObject.SetActive(false);
            float xPos = Random.Range(xMin, xMax);
            float zPos = Random.Range(zMin, zMax);
            transform.position = new Vector3(xPos, transform.position.y, zPos);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SubmarineDropped()
    {
        isSubmarineDropped = true;
    }

    IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Submarine1");
    }
}
