using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    public int lives = 3;

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _uiManager.EnablePausePanel();
            Time.timeScale = 0;
        }
    }

    public void StartSpawnPlayer()
    {
        StartCoroutine(PlayerSpawnRoutine());
    }

    public IEnumerator PlayerSpawnRoutine()
    {
        yield return new WaitForSeconds(2f);
        Vector3 newPosition = new Vector3(0, 30f, 0);
        _player.transform.position = newPosition;
        Instantiate(_player, _player.transform.position, Quaternion.identity);
        FindObjectOfType<FollowPlayer>().setDefaultY(1.58f);
    }
    public void Restart()
    {
        _uiManager.DisableGameOver();
        SceneManager.LoadScene("Level1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        _uiManager.DisablePausePanel();
        Time.timeScale = 1;
    }
}
