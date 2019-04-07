using Assets.Scripts;
using UnityEngine;



public class Keyboard : MonoBehaviour
{
    private AudioSource _keySound;
    private CheckMelody _checkMelody;
    private HiddenBridge _hiddenBridge;

    private void Start()
    {
        _keySound = GetComponent<AudioSource>();
        _checkMelody = GameObject.Find("PlatformKeyboard").GetComponent<CheckMelody>();
        _hiddenBridge = GameObject.Find("PlatformG").GetComponent<HiddenBridge>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _keySound.Play();
            _checkMelody.InputNotes.Add(_keySound.clip.name);
            Debug.Log("Name: " + _keySound.clip.name);

            if (_checkMelody.IsCorrectMelody())
            {
                _hiddenBridge.ShowTheBridge();
            }
        }
    }
}
