using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFindKeyPanel : MonoBehaviour
{
    private UIManager _uiManager;
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            _uiManager.CloseFindKeyInfo();
    }
}
