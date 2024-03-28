using UnityEngine;

public class PlayerMovementSoundController: MonoBehaviour
{
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayWalkSound(int indexPan)
    {
        _audioSource.panStereo = indexPan;
        _audioSource.Play();
    }

}
