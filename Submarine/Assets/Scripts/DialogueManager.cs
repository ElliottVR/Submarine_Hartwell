using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public AudioSource dialogueMS1;
    public AudioSource dialogueSub1;
    public AudioSource dialogueMS2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AudioStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AudioStart()
    {
        yield return new WaitForSeconds(2f);
        dialogueMS1.Play();
        yield return new WaitForSeconds(5f);
        dialogueSub1.Play();
        yield return new WaitForSeconds(4f);
        dialogueMS2.Play();
    }
}
