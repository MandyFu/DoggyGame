using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoor : MonoBehaviour
{
    private UIManager _uiManager;
    private Animator _openDoor;
    private AudioSource _doorOpenSound;

    [SerializeField]
    private GameObject _insertKeyCard;
    [SerializeField]
    private GameObject _smoke;

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _openDoor = GetComponent<Animator>();
        _doorOpenSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var _player = FindObjectOfType<Player>();
            if (_player != null)
            {
                if (_player.hasKeyCard == false)
                {
                    _uiManager.OpenFindKeyInfo();
                }
                else
                {
                    _uiManager.RemoveKeyCard();
                    _player.hasKeyCard = false;
                    _insertKeyCard.SetActive(true);
                    _insertKeyCard.GetComponent<AudioSource>().Play();
                    StartCoroutine(OpenLevelDoorRoutine());
                    _uiManager.EndGame();
                }
            }
        }
    }
    IEnumerator OpenLevelDoorRoutine()
    {
        yield return new WaitForSeconds(2f);
        _doorOpenSound.Play();
        _openDoor.SetTrigger("Open_Door");
        _smoke.SetActive(true);
    }
}

