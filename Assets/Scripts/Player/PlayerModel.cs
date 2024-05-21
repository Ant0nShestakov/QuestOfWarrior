using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerModel : MonoBehaviour, IDataPersistance
{
    private HealthBar _healthBar;
    private CharacterController _characterController;
    private DataPersistanceManager _data;

    [field: SerializeField] public GameModels PlayerProperites { get; private set; }
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public bool IsAttack { get; private set; }
    [field: SerializeField] public List<Skill> Cooldowns { get; set; }

    public bool LockState { get; set; }
    public bool IsBlocked { get; set; }
    public bool IsStay { get; set; }

    public bool IsOnGround { get; set; }
    public bool IsSwim { get; set; }
    public bool IsFreeFly { get; set; }


    private void Awake()
    {
        Debug.Log($"Transform before {transform.position}");
        _characterController = GetComponent<CharacterController>();
        _data = Singelton<DataPersistanceManager>.Instance;
        _data.SetPersistances();
        _data.LoadGame();

        Damage = PlayerProperites.AutoAttackDamage;
        _healthBar = GetComponentInChildren<HealthBar>();
    }

    private void Start()
    {
        Debug.Log($"Transform after {transform.position}");
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

        if(skill is null) 
            return false;

        return true;
    }

    public bool TryCast(CooldownTypes cooldownTypes, float time)
    {
        if (!IsOnGround || IsAttack)
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

    public bool Attacking() => IsAttack = true;
    public bool NoAttacking() => IsAttack = false;

    public void Stay() 
    {
        IsStay = true;
        PlayerProperites.CurrentSpeed = 0;
    }

    public void RegenerationStamina() 
    {
        PlayerProperites.RegenerationStamina();
        _healthBar.UpdateInfo();
    }

    public void RegenerationStamina(int points)
    {
        PlayerProperites.RegenerationStamina(points);
        _healthBar.UpdateInfo();
    }

    public void SetCursorLockState()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        LockState = false;
    }

    public void HealthSelf(int points)
    {
        PlayerProperites.RegenerationHealth(points);
        _healthBar.UpdateInfo();
    }

    public void SetCursorFreeState()
    {
        Cursor.lockState = CursorLockMode.None;
        LockState = true;
    }

    public int GetDamage(int Damage)
    {
        if(!IsBlocked)
            PlayerProperites.CurrentHealth -= Damage;
        return PlayerProperites.CurrentHealth;
    }

    public void LoadData(GameData data)
    {
        if (data.PlayerModel.MaxHealth == 0)
        {
            Debug.Log("Load default data with PlayerModel");
            return;
        }

        PlayerProperites.MaxHealth = data.PlayerModel.MaxHealth;
        PlayerProperites.MaxStamina = data.PlayerModel.MaxStamina;
        PlayerProperites.CurrentHealth = data.PlayerModel.CurrentHealth;
        PlayerProperites.CurrentStamina = data.PlayerModel.CurrentStamina;

        int index = SceneManager.GetActiveScene().buildIndex;

        ObjectPosition positionInfo = data.PlayerPosition.Find(op => op.IndexScene == index);

        if (positionInfo == null)
        {
            Debug.Log("Possition is null");
            return;
        }

        _characterController.enabled = false;
        this.gameObject.transform.position = positionInfo.Position;
        _characterController.enabled = true;
        Debug.Log("Possition loadied");
        Debug.Log(transform.position);
    }

    public void SaveData(ref GameData data)
    {
        Debug.Log("Save data");
        data.PlayerModel = new PlayerDataModel(PlayerProperites);

        int index = SceneManager.GetActiveScene().buildIndex;
        data.SceneIndex = index;

        if (data.PlayerPosition.Count != index)
        {
            data.PlayerPosition.Add(new ObjectPosition(index, this.transform.position));
            return;
        }

        index--;
        data.PlayerPosition[index] = new ObjectPosition(index+1, this.transform.position);
    }
}
