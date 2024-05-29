using UnityEngine;

public class MovementSoundController: MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void PlayWalkSound(int indexPan)
    {
        _audioSource.panStereo = indexPan;
        _audioSource.Play();
    }

}
