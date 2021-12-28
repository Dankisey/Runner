using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class Heart : MonoBehaviour
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    public void ToEmpty()
    {
        Destroy();
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}