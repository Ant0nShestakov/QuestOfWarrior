using UnityEngine;

public class PlayerAttackSoundsManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] _rageSounds;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayRageSound()
    {
        _audioSource.clip = _rageSounds[Random.Range(0, _rageSounds.Length)];
        _audioSource.Play();
    }
}
