using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Input/Bindings")]
public class InputParameters : ScriptableObject 
{
    [field: Header("Attack")]
    [field: SerializeField] public KeyCode AutoAttackBind {  get; private set; }
    [field: SerializeField] public KeyCode BlockBind { get; private set; }
    [field: SerializeField] public KeyCode FirstSpecialAttackBind { get; private set; }
    [field: SerializeField] public KeyCode SecondSpecialAttackBind { get; private set; }
    [field: SerializeField] public KeyCode ThridSpecialAttackBind { get; private set; }
    [field: SerializeField] public KeyCode FourthSpecialAttackBind { get; private set; }
    [field: SerializeField] public KeyCode FifthSpecialAttackBind { get; private set; }
    [field: SerializeField] public KeyCode SixSpecialAttackBind { get; private set; }
    [field: SerializeField] public KeyCode SeventhSpecialAttackBind { get; private set; }
    [field: SerializeField] public KeyCode EighthSpecialAttackBind { get; private set; }
}