using UnityEngine;
using Zenject;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private Skill _skill;

    private UnitModel _unitModel;
    private Animator _animator;

    [Inject]
    public void Construct(UnitModel unitModel)
    {
        _unitModel = unitModel;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (_unitModel.Cooldowns.Find(skill => skill.name == _skill.name))
            _animator.SetBool("Active", true);
        else
            _animator.SetBool("Active", false);

    }

    public void AddSkill()
    {
        if (_unitModel.Cooldowns.Find(skill => skill.name == _skill.name))
        {
            Debug.LogError($"Skill {_skill.name} contains");
            return;
        }

        _unitModel.Cooldowns.Add(_skill);
        _animator.SetBool("Active", true);

        Debug.Log($"Skill {_skill.name} added");
    }

    public void RemoveSkill()
    {
        var skill = _unitModel.Cooldowns.Find(skill => skill.name == _skill.name);
        if (skill == null)
        {
            Debug.LogError($"Skill {_skill.name} not contains");
            return;
        }

        _unitModel.Cooldowns.Remove(skill);
        _animator.SetBool("Active", false);

        Debug.Log($"Skill {_skill.name} removed");
    }
}
