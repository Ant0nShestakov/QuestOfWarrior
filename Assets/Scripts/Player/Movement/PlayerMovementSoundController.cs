using UnityEngine;

public class PlayerMovementSoundController: MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start() =>
        _audioSource = GetComponent<AudioSource>();

    public void PlayWalkSound(int indexPan)
    {
        _audioSource.panStereo = indexPan;
        _audioSource.Play();
    }

}
