using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider MusicVolumeSlider;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    public void UpdateVolume()
    {
        _gameManager.GetComponent<AudioSource>().volume = MusicVolumeSlider.value;
    }
}