using UnityEngine;

public class CloseInfoPanel : MonoBehaviour
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
            _uiManager.CloseInfoPanel();
    }
}
