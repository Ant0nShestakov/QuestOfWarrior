using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //[SerializeField] private PlayerModel _playerModel;
    //[SerializeField] private Image _healthBar;
    //[SerializeField] private Image _staminaBar;

    //private float _maxHP;
    //private float _maxStamina;

    //private TMP_Text _textOnImageHpBar;
    //private TMP_Text _textOnImageStaminaBar;

    //private void Awake()
    //{
    //    _textOnImageHpBar = _healthBar.GetComponentInChildren<TMP_Text>();
    //    _textOnImageStaminaBar = _staminaBar.GetComponentInChildren<TMP_Text>();
    //}

    //private void OnEnable()
    //{
    //    _playerModel.UpdateStatsEvent += UpdateInfo;
    //}

    //private void Start()
    //{
    //    _playerModel = GetComponentInParent<PlayerModel>();
    //    _maxHP = _playerModel.PlayerProperites.MaxHealth;
    //    _maxStamina = _playerModel.PlayerProperites.MaxStamina;
    //    UpdateInfo();
    //}

    //private void OnDisable()
    //{
    //    _playerModel.UpdateStatsEvent -= UpdateInfo;
    //}

    //public void UpdateInfo() 
    //{
    //    _textOnImageHpBar.text = _playerModel.PlayerProperites.CurrentHealth.ToString() + " / " + _maxHP.ToString();
    //    _textOnImageStaminaBar.text = _playerModel.PlayerProperites.CurrentStamina.ToString() + " / " + _maxStamina.ToString();
    //}
}
