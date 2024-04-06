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

    private void Awake()
    {
        _textOnImageHpBar = _healthBar.GetComponentInChildren<Text>();
        _textOnImageStaminaBar = _staminaBar.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        _playerModel = GetComponentInParent<PlayerModel>();
        _maxHP = _playerModel.Health;
        _maxStamina = _playerModel.Stamina;
        UpdateInfo();
    }

    public void UpdateInfo() 
    {
        _textOnImageHpBar.text = _playerModel.Health.ToString() + " / " + _maxHP.ToString();
        _textOnImageStaminaBar.text = _playerModel.Stamina.ToString() + " / " + _maxStamina.ToString();
    }
}
