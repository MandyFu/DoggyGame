using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    [SerializeField]
    private GameObject _twinkkleTwinkleNotes;

    private AudioSource _playNotes;
    private UIManager _uiManager;

    private void Start()
    {
        _playNotes = GetComponent<AudioSource>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.GetComponent<Renderer>().material.color = Color.green;
            _uiManager.OpenHintInfo();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            transform.GetComponent<Renderer>().material.color = Color.red;
    }

    public void PlayNotesAndMusic()
    {
        _uiManager.CloseHintInfo();
        _playNotes.Play();
        _twinkkleTwinkleNotes.GetComponent<Animator>().SetTrigger("Play_Notes");
    }
}
