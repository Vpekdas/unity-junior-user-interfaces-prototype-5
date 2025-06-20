using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public int Difficulty;
    private Button _button;
    private GameManager _gameManager;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void SetDifficulty()
    {
        _gameManager.StartGame(Difficulty);
    }
}