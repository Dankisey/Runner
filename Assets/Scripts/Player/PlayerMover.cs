using UnityEngine;

[RequireComponent(typeof(Player))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private ScoreDisplay _scoreDisplay;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    private Vector3 _targetPosition;
    private float _defaultAnimatorSpeed;
    private float _scaleFactor = 1;
    private Animator _animator;

    private void OnEnable()
    {
        _scoreDisplay.IncreaseSpeedScale += ChangeScaleFactor;
    }

    private void OnDisable()
    {
        _scoreDisplay.IncreaseSpeedScale -= ChangeScaleFactor;
    }

    private void ChangeScaleFactor(float scaleFactor)
    {
        _scaleFactor = scaleFactor;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _defaultAnimatorSpeed = _animator.speed;

        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * _scaleFactor * Time.deltaTime);

        _animator.speed = _defaultAnimatorSpeed * _scaleFactor;
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
            SetNextPosition(_stepSize);
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
            SetNextPosition(_stepSize * -1);
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }
}