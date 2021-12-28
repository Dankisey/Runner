using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]

public class BackGroundParalax : MonoBehaviour
{
    [SerializeField] private ScoreDisplay _scoreDisplay;
    [SerializeField] private float _speed;

    private RawImage _image;
    private float _imagePositionX;
    private float _scaleFactor = 1;

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
        _image = GetComponent<RawImage>();
        _imagePositionX = _image.uvRect.x;
    }

    
    private void Update()
    {
        _imagePositionX += _speed * _scaleFactor * Time.deltaTime ;

        if (_imagePositionX > 1000)
            _imagePositionX = 0;

        _image.uvRect = new Rect(_imagePositionX, 0, _image.uvRect.width, _image.uvRect.height);
    }

    
}
