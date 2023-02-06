using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrelCollector : MonoBehaviour
{
    public int barrelsNeeded = 5;
    public int barrelsCollected = 0;

    public void CollectBarrel()
    {
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
