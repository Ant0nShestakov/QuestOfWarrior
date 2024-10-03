using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CooldownUI : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _skills;
    private UnitModel _playerModel;
    private int i;

    public void Construct(UnitModel playerModel)
    {
        _playerModel = playerModel;
    }

    private void Start()
    {
        i = 0;
        StartCoroutine(CheckCooldown());
    }

    private IEnumerator CheckCooldown()
    {

        while (true)
        {
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
