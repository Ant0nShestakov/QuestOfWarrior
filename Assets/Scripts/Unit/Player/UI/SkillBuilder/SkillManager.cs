using UnityEngine;

public class SkillManager : MonoBehaviour
{
    //    [SerializeField] private Skill _skill;

    //    private PlayerModel _playerModel;
    //    private Animator _animator;

    //    private void Awake()
    //    {
    //        _playerModel = GetComponentInParent<PlayerModel>();

    //        if (_playerModel == null)
    //            Debug.LogError("PlayerModel not found");

    //        _animator = GetComponent<Animator>();
    //    }

    //    private void OnEnable()
    //    {
    //        if(_playerModel.Cooldowns.Find(skill => skill.name == _skill.name))
    //            _animator.SetBool("Active", true);
    //        else
    //            _animator.SetBool("Active", false);

    //    }

    //    public void AddSkill()
    //    {
    //        if (_playerModel.Cooldowns.Find(skill => skill.name == _skill.name))
    //        {
    //            Debug.LogError($"Skill {_skill.name} contains");
    //            return;
    //        }

    //        _playerModel.Cooldowns.Add(_skill);
    //        _animator.SetBool("Active", true);

    //        Debug.Log($"Skill {_skill.name} added");
    //    }

    //    public void RemoveSkill()
    //    {
    //        var skill = _playerModel.Cooldowns.Find(skill => skill.name == _skill.name);
    //        if (skill == null)
    //        {
    //            Debug.LogError($"Skill {_skill.name} not contains");
    //            return;
    //        }

    //        _playerModel.Cooldowns.Remove(skill);
    //        _animator.SetBool("Active", false);

    //        Debug.Log($"Skill {_skill.name} removed");
    //    }
}
