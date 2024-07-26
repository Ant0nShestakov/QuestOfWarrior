using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

[RequireComponent(typeof(CharacterController), typeof(InventoryManager))]
public class PlayerModel : MonoBehaviour, IDataPersistance, IDamageable
{
    private CharacterController _characterController;
    private DataPersistanceManager _data;

    public event Action UpdateStatsEvent;

    [field: SerializeField] public PlayerStats PlayerProperites { get; private set; }
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public bool IsAttack { get; private set; }
    [field: SerializeField] public List<Skill> Cooldowns { get; private set; }
    public CharacterController CharacterController => _characterController;
    public InventoryManager InventoryManager { get; private set; } 
    public bool IsLocked { get; set; }
    public Vector3 SavePosition { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsStay { get; set; }

    public bool IsGrounded { get; set; }
    public bool IsSwim { get; set; }
    public bool IsFreeFly { get; set; }

    [Inject]
    public void Construct(DataPersistanceManager dataPersistance)
    {
        _data = dataPersistance;
    }

    private void Awake()
    {
        IsLocked = true;
        Debug.Log($"Transform before {transform.position}");
        _characterController = GetComponent<CharacterController>();
        _data.SetPersistances();
        _data.LoadGame();
        Damage = PlayerProperites.AutoAttackDamage;
        InventoryManager = GetComponent<InventoryManager>();
    }

    private void OnDisable()
    {
        foreach(var cooldown in Cooldowns)
            cooldown.SetDefaultState();
        PlayerProperites.SetDefaultState();
    }

    private bool CheckStaminaForAttack(Skill cd)
    {
        if (PlayerProperites.CurrentStamina - cd.Stamina < 0)
            return false;
        return true;
    }

    private bool TryGetCooldownForType(CooldownTypes cooldownTypes, out Skill skill)
    {
        skill = Cooldowns.SingleOrDefault(cd => cd.Type == cooldownTypes);

        if(skill == null) 
            return false;

        return true;
    }

    private IEnumerator LoadCoroutine()
    {
        yield return new WaitForSeconds(1);
        IsLocked = false;
    }

    public bool TryCast(CooldownTypes cooldownTypes, float time)
    {
        if (!IsGrounded || IsAttack)
            return false;

        if (!TryGetCooldownForType(cooldownTypes, out Skill cooldown))
            return false;

        if (!CheckStaminaForAttack(cooldown))
            return false;

        if (!cooldown.CheckCooldownStemp(time))
            return false;

        Damage = cooldown.Damage;
        PlayerProperites.CurrentStamina -= cooldown.Stamina;
        return true;
    }

    public void SetWalkSpeedState() 
    {
        IsStay = false;
        PlayerProperites.SetWalkSpeed();
    }

    public void Attacking()
    {
        UpdateStatsInfo();
        IsAttack = true;
    }

    public bool NoAttacking() => IsAttack = false;

    public void Stay() 
    {
        IsStay = true;
        PlayerProperites.CurrentSpeed = 0;
    }

    public void RegenerationStamina() 
    {
        PlayerProperites.RegenerationStamina();
        UpdateStatsInfo();
    }

    public void RegenerationStamina(int points)
    {
        PlayerProperites.RegenerationStamina(points);
        UpdateStatsInfo();
    }

    public void SetCursorLockState()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        IsLocked = false;
    }

    public void HealthSelf(int points)
    {
        PlayerProperites.RegenerationHealth(points);
        UpdateStatsInfo();
    }

    public void SetCursorFreeState()
    {
        Cursor.lockState = CursorLockMode.None;
        IsLocked = true;
    }

    public void LoadData(GameData data)
    {
        if (data.PlayerModel.MaxHealth != 0)
        {
            PlayerProperites.MaxHealth = data.PlayerModel.MaxHealth;
            PlayerProperites.MaxStamina = data.PlayerModel.MaxStamina;
            PlayerProperites.CurrentHealth = data.PlayerModel.CurrentHealth;
            PlayerProperites.CurrentStamina = data.PlayerModel.CurrentStamina;
        }

        int index = SceneManager.GetActiveScene().buildIndex;

        ObjectPosition positionInfo = data.PlayerPosition.Find(op => op.IndexScene == index);

        if (positionInfo != null)
        {
            _characterController.enabled = false;
            Debug.Log($"Character off");
            this.gameObject.transform.SetPositionAndRotation(positionInfo.Position, positionInfo.Rotation);
            _characterController.enabled = true;
            Debug.Log("Possition loadied");
            Debug.Log(transform.position);
        }

        if(data.PlayerModel.Skills.Count != 0)
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
                if (Cooldowns.Find(skill => skill.name == currentSkill.name) != null)
                {
                    Debug.LogError($"Skill {skill} in Cooldowns");
                    continue;
                }

                Cooldowns.Add(currentSkill);
            }

        }
        StartCoroutine(LoadCoroutine());
    }

    public void SaveData(ref GameData data)
    {
        data.PlayerModel = new PlayerDataModel(PlayerProperites);

        foreach(var skill in Cooldowns)
            data.PlayerModel.Skills.Add(new SkillData(skill));

        int index = SceneManager.GetActiveScene().buildIndex;
        data.SceneIndex = index;

        ObjectPosition positionInfo = data.PlayerPosition.Find(op => op.IndexScene == index);

        if(positionInfo == null) 
        {
            data.PlayerPosition.Add(new ObjectPosition(index, SavePosition, this.gameObject.transform.rotation));
            return;
        }

        Debug.Log($"GObject position in save: {SavePosition}");
        index--;
        data.PlayerPosition[index] = new ObjectPosition(index+1, SavePosition, transform.rotation);
    }

    public void UpdateStatsInfo() => UpdateStatsEvent?.Invoke();

    public void ApplyDamage(float damage)
    {
        if (!IsBlocked)
        {
            PlayerProperites.CurrentHealth -= damage;

            if (PlayerProperites.CurrentHealth <= 0)
                SceneManager.LoadScene(6);

            UpdateStatsInfo();
        }
    }
}
