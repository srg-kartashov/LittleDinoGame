using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{

    public Sprite OnSprite;
    public Sprite OffSprite;
    private bool _enable = true;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void Click()
    {
        _enable = !_enable;
        _image.sprite = _enable ? OnSprite : OffSprite;
    }
}
