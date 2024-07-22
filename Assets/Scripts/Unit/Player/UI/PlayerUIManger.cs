using TMPro;
using UnityEngine;

public class PlayerUIManger : MonoBehaviour, IUIVisitor
{
    [SerializeField] private TMP_Text _uiHintText;
    [SerializeField] private UIhint _uiHint;

    public void Visit(DoorManager door)
    {
        _uiHintText.gameObject.SetActive(true);
        _uiHintText.text = _uiHint.DoorHint;
    }

    public void Visit(ChestManager chest)
    {
        _uiHintText.gameObject.SetActive(true);
        _uiHintText.text = _uiHint.ChestHint;
    }

    public void Visit(LoadLvL loader)
    {
        _uiHintText.gameObject.SetActive(true);
        _uiHintText.text = _uiHint.LvLHint;
    }

    public void Visit()
    {
        _uiHintText.gameObject.SetActive(false);
        _uiHintText.text = null;
    }
}