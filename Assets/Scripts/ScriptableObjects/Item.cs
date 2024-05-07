using UnityEngine;

public enum TypeItem
{
    health,
    energy
}

[CreateAssetMenu(fileName = "Item", menuName = "ScritableObjects/Item")]
public class Item : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Image { get; private set; }
    [field: SerializeField] public TypeItem Type { get; private set; }
    [field: SerializeField] public int Value { get; private set; }
}
