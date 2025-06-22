using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Targets;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI LivesText;
    public Button RestartButton;
    public GameObject TitleScreen;
    public GameObject PauseScreen;
    public bool IsGameActive;
    public bool IsGamePaused;
    private float _spawnRate = 1.0f;
    private int _score;
    private int _lives;

    public int Lives => _lives;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    IEnumerator SpawnTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        ScoreText.text = "Score: " + _score;
    }

    public void UpdateLives(int liveToSub)
    {
        if (_lives > 0)
        {
            _lives -= liveToSub;
        }
        LivesText.text = "Lives: " + _lives;
    }

    public void GameOver()
    {
        IsGameActive = false;
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        _score = 0;
        _lives = 3;
        IsGameActive = true;
        IsGamePaused = false;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        UpdateLives(0);
        TitleScreen.SetActive(false);
        _spawnRate /= difficulty;
    }

    public void PauseGame()
    {
        if (IsGameActive)
        {
            IsGamePaused = !IsGamePaused;
            Time.timeScale = IsGamePaused ? 0 : 1;
            PauseScreen.SetActive(IsGamePaused);
        }
    }
}