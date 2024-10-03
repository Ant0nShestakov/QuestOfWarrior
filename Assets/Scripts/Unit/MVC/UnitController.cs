using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

[RequireComponent(typeof(UnitView), typeof(InputController))]
public sealed class UnitController : Controller, IDataPersistance
{
    private UnitModel _model;
    private UnitView _view;

    private IEnumerable<IHandler> _handlers;

    public override IDamageable Damageable => _model;

    public AimHandler AimHandler => (AimHandler)_handlers
        .Where(handler => handler is AimHandler).FirstOrDefault();

    [Inject]
    public void Construct(UnitModel model, IHandler[] handlers)
    {
        _model = model;
        _handlers = handlers;
    }

    private void Awake()
    {
        _view = GetComponent<UnitView>();
    }

    private void OnEnable()
    {
        _model.UpdateStatsEvent += OnDamage;
        _model.UpdateStatsEvent += UpdateStatsOnHUD;
    }

    private void Update()
    {
        foreach (var handler in _handlers)
        {
            handler.Update();
        }
    }

    private void UpdateStatsOnHUD()
    {
        _view.UpdateHP(_model);
    }

    private void OnDisable()
    {
        _model.UpdateStatsEvent -= OnDamage;
        _model.UpdateStatsEvent -= UpdateStatsOnHUD;
    }

    private void OnDamage()
    {
        if (_model.CurrentHealth <= 0)
            Destroy(gameObject);
    }

    public void LoadData(GameData data)
    {
        if (data.PlayerModel.MaxHealth != 0)
        {
            _model.PlayerProperites.MaxHealth = data.PlayerModel.MaxHealth;
            _model.PlayerProperites.MaxStamina = data.PlayerModel.MaxStamina;
            _model.PlayerProperites.CurrentHealth = data.PlayerModel.CurrentHealth;
            _model.PlayerProperites.CurrentStamina = data.PlayerModel.CurrentStamina;
        }

        int index = SceneManager.GetActiveScene().buildIndex;

        ObjectPosition positionInfo = data.PlayerPosition.Find(op => op.IndexScene == index);

        if (positionInfo != null)
            gameObject.transform.SetPositionAndRotation(positionInfo.Position, positionInfo.Rotation);

        if (data.PlayerModel.Skills.Count != 0)
        {
            foreach (SkillData skill in data.PlayerModel.Skills)
            {
                Skill currentSkill = (Skill)ScriptableObject.CreateInstance(typeof(Skill));

                currentSkill.name = skill.Name;
                currentSkill.Type = skill.CooldownType;
                currentSkill.Damage = skill.Damage;
                currentSkill.Stamina = skill.Stamina;
                currentSkill.CooldownTime = skill.CooldownTime;
                currentSkill.CooldownCurrentTime = skill.CooldownCurrentTime;
                if (_model.Cooldowns.Find(skill => skill.name == currentSkill.name) != null)
                    continue;

                _model.Cooldowns.Add(currentSkill);
            }

        }
    }

    public void SaveData(ref GameData data)
    {
        data.PlayerModel = new PlayerDataModel(_model.PlayerProperites);

        foreach (var skill in _model.Cooldowns)
            data.PlayerModel.Skills.Add(new SkillData(skill));

        int index = SceneManager.GetActiveScene().buildIndex;
        data.SceneIndex = index;

        ObjectPosition positionInfo = data.PlayerPosition.Find(op => op.IndexScene == index);

        if (positionInfo == null)
        {
            data.PlayerPosition.Add(new ObjectPosition(index, _model.SavePosition, this.gameObject.transform.rotation));
            return;
        }

        index--;
        data.PlayerPosition[index] = new ObjectPosition(index + 1, _model.SavePosition, transform.rotation);
    }

    public void CanceledAttack() => _model.IsAttack = false;
}