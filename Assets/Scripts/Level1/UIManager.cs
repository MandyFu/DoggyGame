using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _livesUpdate;
    [SerializeField]
    private GameObject _findKeyPanel;
    [SerializeField]
    private GameObject _hintPanel;
    [SerializeField]
    private GameObject _inventory;
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private GameObject _endGamePanel;
    [SerializeField]
    private GameObject _infoPanel;
    [SerializeField]
    private GameObject _pausePanel;

    public void CloseInfoPanel()
    {
        _infoPanel.SetActive(false);
    }
    public void EnablePausePanel()
    {
        _pausePanel.SetActive(true);
    }
    public void DisablePausePanel()
    {
        _pausePanel.SetActive(false);
    }
    public void UpdateLives(int currentLives)
    {
        _livesUpdate.text = "X " + currentLives;
    }
    public void OpenFindKeyInfo()
    {
        _findKeyPanel.SetActive(true);
    }
    public void CloseFindKeyInfo()
    {
        _findKeyPanel.SetActive(false);
    }
    public void OpenHintInfo()
    {
        _hintPanel.SetActive(true);
    }
    public void CloseHintInfo()
    {
        _hintPanel.SetActive(false);
    }
    public void CollectKeyCard()
    {
        _inventory.SetActive(true);
    }
    public void RemoveKeyCard()
    {
        _inventory.SetActive(false);
    }
    public void EnableGameOver()
    {
        _gameOverPanel.SetActive(true);
    }
    public void DisableGameOver()
    {
        _gameOverPanel.SetActive(false);
    }
    public void EndGame()
    {
        StartCoroutine(ShowEndGameRoutine());
    }
    IEnumerator ShowEndGameRoutine()
    {
        yield return new WaitForSeconds(4f);
        _endGamePanel.SetActive(true);
        var aimn = _endGamePanel.GetComponent<Animator>();
        aimn.updateMode = AnimatorUpdateMode.UnscaledTime;
        Time.timeScale = 0;
    }
}

