using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerModel _playerModel;
    [SerializeField] private Image _healthBar;

    private float _maxHP;
    private Text _textOnImage;

    void Start()
    {
        _maxHP = _playerModel.Health;
        _textOnImage = GetComponentInChildren<Text>();
    }

    void Update()
    {
        _textOnImage.text = _playerModel.Health.ToString() + " / " + _maxHP.ToString();
    }
}
