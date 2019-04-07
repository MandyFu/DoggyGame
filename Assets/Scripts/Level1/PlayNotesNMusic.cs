using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNotesNMusic : MonoBehaviour
{
    private HintButton _hintButton;
    void Start()
    {
        _hintButton = GameObject.Find("Hint_Button").GetComponent<HintButton>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            _hintButton.PlayNotesAndMusic();
    }
}
