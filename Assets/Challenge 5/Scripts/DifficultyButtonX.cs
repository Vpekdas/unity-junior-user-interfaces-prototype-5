using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonX : MonoBehaviour
{
    public int Difficulty;
    private Button _button;
    private GameManagerX _gameManagerX;

    void Start()
    {
        _gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
    }

    /* When a button is clicked, call the StartGame() method  and pass it the difficulty value (1, 2, 3) from the button  */
    void SetDifficulty()
    {
        _gameManagerX.StartGame(Difficulty);
    }
}