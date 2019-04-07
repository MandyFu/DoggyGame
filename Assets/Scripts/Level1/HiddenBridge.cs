using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenBridge : MonoBehaviour
{
    [SerializeField]
    private GameObject _hiddenBridge;
    private AudioSource _youWinSound;

    private void Start()
    {
        _youWinSound = GetComponent<AudioSource>();
    }
    public void ShowTheBridge()
    {
        StartCoroutine(ShowTheBridgeRoutine());
    }
    public IEnumerator ShowTheBridgeRoutine()
    {
        yield return new WaitForSeconds(1f);
        _youWinSound.Play();
        yield return new WaitForSeconds(0.5f);
        _hiddenBridge.SetActive(true);
    }
}
