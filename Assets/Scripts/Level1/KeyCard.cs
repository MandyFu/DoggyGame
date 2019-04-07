using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard : MonoBehaviour
{
    private AudioSource _keyCardSound;
    private UIManager _uiManager;

    private bool _destroyKeyCard = false;
    [SerializeField]
    private GameObject _keyCard;
    [SerializeField]
    private GameObject _fallingBridge;

    private void Start()
    {
        _keyCardSound = GameObject.Find("KeyCardSound").GetComponent<AudioSource>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _keyCardSound.Play();
            _keyCard.SetActive(false);
            _destroyKeyCard = true;
            _fallingBridge.SetActive(true);
            FindObjectOfType<Player>().hasKeyCard = true;
            _uiManager.CollectKeyCard();
        }
    }
    
    public void ShowKeyCard()
    {
        _keyCard.SetActive(true);
        _destroyKeyCard = false;
    }
}
