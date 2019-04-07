using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoesHint : MonoBehaviour
{
    [SerializeField]
    private GameObject _notes;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _notes.GetComponent<Animator>().SetTrigger("StepOnPlatform");
            _notes.GetComponent<AudioSource>().Play();
        }
    }
}
