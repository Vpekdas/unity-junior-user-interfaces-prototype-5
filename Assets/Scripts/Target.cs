using UnityEngine;

public class Target : MonoBehaviour
{
    public int PointValue;
    public ParticleSystem ExplosionParticle;
    private Rigidbody _targetRB;
    private readonly float _minSpeed = 12.0f;
    private readonly float _maxSpeed = 16.0f;
    private readonly float _maxTorque = 5.0f;
    private readonly float _xRange = 4.0f;
    private readonly float _ySpawnPos = -6.0f;
    private GameManager _gameManager;
    private MouseFollow _mouseTrail;

    void Start()
    {
        _targetRB = GetComponent<Rigidbody>();
        _targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _mouseTrail = GameObject.Find("Mouse Trail").GetComponent<MouseFollow>();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-_maxTorque, _maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_gameManager.IsGameActive)
        {
            if (_mouseTrail.Trail.enabled)
            {
                Destroy(gameObject);
                Instantiate(ExplosionParticle, gameObject.transform.position, ExplosionParticle.transform.rotation);
                _gameManager.UpdateScore(PointValue);
                if (gameObject.CompareTag("Bad"))
                {
                    _gameManager.GameOver();
                    _gameManager.UpdateLives(3);

                }
            }
            if (other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad"))
            {
                _gameManager.UpdateLives(1);
            }
            if (_gameManager.Lives <= 0)
            {
                _gameManager.GameOver();
            }
        }
    }
}