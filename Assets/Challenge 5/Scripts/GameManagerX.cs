using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI TimerText;
    public GameObject TitleScreen;
    public Button RestartButton;
    public List<GameObject> TargetPrefabs;
    public bool IsGameActive;
    private readonly float _minValueX = -3.75f; //  x value of the center of the left-most square
    private readonly float _minValueY = -3.75f; //  y value of the center of the bottom-most square
    private readonly float _spaceBetweenSquares = 2.5f;
    private int _score;
    private int _timer;
    private float _spawnRate = 1.5f;

    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    public void StartGame(int difficulty)
    {
        _spawnRate /= difficulty;
        IsGameActive = true;
        StartCoroutine(SpawnTarget());
        _score = 0;
        UpdateScore(0);
        TitleScreen.SetActive(false);
        _timer = 60;
        StartCoroutine(TimerRoutine());
    }

    // While game is active spawn a random target
    IEnumerator SpawnTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, TargetPrefabs.Count);
            if (IsGameActive)
            {
                Instantiate(TargetPrefabs[index], RandomSpawnPosition(), TargetPrefabs[index].transform.rotation);
            }
        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = _minValueX + (RandomSquareIndex() * _spaceBetweenSquares);
        float spawnPosY = _minValueY + (RandomSquareIndex() * _spaceBetweenSquares);
        Vector3 spawnPosition = new(spawnPosX, spawnPosY, 0);
        return spawnPosition;
    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        ScoreText.text = "Score: " + _score;
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
        IsGameActive = false;
        StopCoroutine(TimerRoutine());
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator TimerRoutine()
    {
        while (_timer > 0 && IsGameActive)
        {
            _timer--;
            TimerText.text = "Time: " + _timer;
            yield return new WaitForSeconds(1.0f);
        }
        GameOver();
    }
}