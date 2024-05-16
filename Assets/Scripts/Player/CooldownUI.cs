using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CooldownUI : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> _skills;
    [SerializeField] private List<Skill> _cooldowns;

    private void Start()
    {
        StartCoroutine(CheckCooldown());
    }

    private IEnumerator CheckCooldown()
    {
        while(true) 
        {
            for (int i = 0; i < _skills.Count; i++)
            {
                if (_cooldowns[i].CooldownCurrentTime + _cooldowns[i].CooldownTime - Time.time > 0.5f)
                    _skills[i].text = Mathf.Round(_cooldowns[i].CooldownCurrentTime + _cooldowns[i].CooldownTime - Time.time).ToString();
                else
                    _skills[i].text = string.Empty;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
