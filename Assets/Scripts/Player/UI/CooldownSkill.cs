using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownSkill : MonoBehaviour
{
    public TMP_Text _text;
    public Image _img;

    private void Start()
    {
        _text = GetComponentInChildren<TMP_Text>();
        _img = GetComponent<Image>();
    }

    public void UpdateOnUI(Sprite img, string value)
    {
        _img.sprite = img;
        _text.text = value;  
    }
}
