using UnityEngine;

[CreateAssetMenu(fileName = "UIhint", menuName = "ScritableObjects/UIhint")]
public class UIhint : ScriptableObject
{
    [field: SerializeField] public string ChestHint {  get; private set; }
    [field: SerializeField] public string DoorHint { get; private set; }
    [field: SerializeField] public string LvLHint { get; private set; }
}