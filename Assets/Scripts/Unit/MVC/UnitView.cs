using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent (typeof(Animator), typeof(UnitController))]
public sealed class UnitView : MonoBehaviour
{
    [SerializeField] private float _dampTime;
    //[SerializeField] private AudioSource _audioSource;

    [SerializeField] private TMP_Text _text;

    private Animator _animator;

    private IFSM[] _fsms;

    public Animator Animator => _animator;

    [Inject]
    public void Construct(IFSM[] fsms)
    {
        _fsms = fsms;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        foreach (var fsm in _fsms) 
            fsm.Update();
    }

    public void UpdateHP(UnitModel model)
    {
        _text.text = model.CurrentHealth.ToString();
    }

    public void AnimateMovement(in Vector2 moveVector)
    {
        _animator.SetFloat("hInput", moveVector.x, _dampTime, Time.deltaTime);
        _animator.SetFloat("vInput", moveVector.y, _dampTime, Time.deltaTime);
    }

    //public void PlayWalkSound(int indexPan)
    //{
    //    _audioSource.panStereo = indexPan;
    //    _audioSource.Play();
    //}
}