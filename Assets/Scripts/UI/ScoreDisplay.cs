using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreDisplay;
    [SerializeField] private float _scoreIncreaseTime;
    [SerializeField] private float _scaleFactorStep;
    [SerializeField] private int _speedIncreaseStep;

    public event UnityAction<float> IncreaseSpeedScale;
    public float ScaleFactor => _scaleFactor;
    public int Score => _score;

    private float _elapsedTime = 0;
    private int _score = 0;
    private float _scaleFactor = 1;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _scoreIncreaseTime)
        {
            _elapsedTime = 0;
            _score++;
            _scoreDisplay.text = _score.ToString();
        }

        if (_score != 0 && _score % _speedIncreaseStep == 0)
        {
            _scaleFactor += _scaleFactorStep;
            IncreaseSpeedScale?.Invoke(_scaleFactor);
        }
    }
}