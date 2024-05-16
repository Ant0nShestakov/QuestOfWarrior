using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> skills;
    [SerializeField] private List<Skill> cooldowns;

    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(CheckCooldown());
    }

    private IEnumerator CheckCooldown()
    {
        while(true) 
        {
            for (int i = 0; i < skills.Count; i++)
            {
                if (cooldowns[i].CooldownCurrentTime + cooldowns[i].CooldownTime - Time.time > 0.5f)
                    skills[i].text = Mathf.Round(cooldowns[i].CooldownCurrentTime + cooldowns[i].CooldownTime - Time.time).ToString();
                else
                    skills[i].text = string.Empty;
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
