using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private ScoreDisplay _scoreDisplay;
    private float _scaleFactor = 1;

    public void SetScoreDisplay(ScoreDisplay scoreDisplay)
    {
        _scoreDisplay = scoreDisplay;
    }

    private void ChangeScaleFactor(float scaleFactor)
    {
        _scaleFactor = scaleFactor;
    }

    private void Update()
    {
        transform.Translate(Vector3.left * _speed * _scoreDisplay.ScaleFactor * Time.deltaTime);
    }
}