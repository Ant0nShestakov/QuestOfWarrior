using UnityEngine;

[CreateAssetMenu(fileName = "GameModels", menuName = "ScritableObjects/Models")]
public class GameModels : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Health { get; private set; }
}
