using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerModel _playerModel;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _staminaBar;

    private float _maxHP;
    private float _maxStamina;

    private Text _textOnImageHpBar;
    private Text _textOnImageStaminaBar;

    void Start()
    {
        _maxHP = _playerModel.Health;
        _maxStamina = _playerModel.Stamina;

        _textOnImageHpBar = _healthBar.GetComponentInChildren<Text>();
        _textOnImageStaminaBar = _staminaBar.GetComponentInChildren<Text>();
    }

    void Update()
    {
        _textOnImageHpBar.text = _playerModel.Health.ToString() + " / " + _maxHP.ToString();
        _textOnImageStaminaBar.text = _playerModel.Stamina.ToString() + " / " + _maxStamina.ToString();
    }
}
