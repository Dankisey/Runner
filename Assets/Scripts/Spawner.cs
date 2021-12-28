using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private ScoreDisplay _scoreDisplay;
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _startIntervalBetweenSpawn;

    private float _elapsedTime = 0;
    private float _secondsBetweenSpawn;

    private void OnEnable()
    {
        _scoreDisplay.IncreaseSpeedScale += ChangeSpawnInterval;
    }

    private void OnDisable()
    {
        _scoreDisplay.IncreaseSpeedScale -= ChangeSpawnInterval;
    }

    private void Start()
    {
        _secondsBetweenSpawn = _startIntervalBetweenSpawn;

        foreach (var enemy in _enemyPrefabs)
        {
            Initialize(enemy);        
        }
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            } 
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.GetComponent<EnemyMover>().SetScoreDisplay(_scoreDisplay);
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private void ChangeSpawnInterval(float scaleFactor)
    {
        _secondsBetweenSpawn = _startIntervalBetweenSpawn / scaleFactor;
    }
}