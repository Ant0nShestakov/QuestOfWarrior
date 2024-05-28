using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CooldownUI : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _skills;
    private PlayerModel _playerModel;
    private int i;
    private void Start()
    {
        _playerModel = Singelton<PlayerModel>.Instance;
        i = 0;
        StartCoroutine(CheckCooldown());
    }

    private IEnumerator CheckCooldown()
    {

        while(true) 
        {
            //for (int i = 0; i < _playerModel.Cooldowns.Count; i++)
            //{
            //    if (_playerModel.Cooldowns[i].CooldownCurrentTime + _playerModel.Cooldowns[i].CooldownTime - Time.time > 0.5f)
            //        _skills[i].text = Mathf.Round(_playerModel.Cooldowns[i].CooldownCurrentTime + _playerModel.Cooldowns[i].CooldownTime - Time.time).ToString();
            //    else
            //        _skills[i].text = string.Empty;
            //}

            foreach (var skill in _playerModel.Cooldowns)
            {
                if (skill.Type == CooldownTypes.AutoAttack)
                    continue;

                if (skill.CooldownCurrentTime + skill.CooldownTime - Time.time > 0.5f)
                    _skills[i].text = Mathf.Round(skill.CooldownCurrentTime + skill.CooldownTime - Time.time).ToString();
                else
                    _skills[i].text = string.Empty;
                i++;
            }
            i = 0;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
