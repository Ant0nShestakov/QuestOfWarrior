using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private Skill _skill;
    private PlayerModel _playerModel;

    void Start()
    {
        _playerModel = GetComponentInParent<PlayerModel>();

        if (_playerModel == null)
            Debug.LogError("PlayerModel not found");
    }

    public void AddSkill()
    {
        if (_playerModel.Cooldowns.Contains(_skill))
        {
            Debug.LogError($"Skill {_skill.name} contains");
            return;
        }
        _playerModel.Cooldowns.Add(_skill);
        Debug.Log($"Skill {_skill.name} added");
    }

    public void RemoveSkill()
    {
        if (!_playerModel.Cooldowns.Contains(_skill))
        {
            Debug.LogError($"Skill {_skill.name} not contains");
            return;
        }

        _playerModel.Cooldowns.Remove(_skill);
        Debug.Log($"Skill {_skill.name} removed");
    }
}
