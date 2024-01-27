using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioClip[] _characterSwitchingAudio;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void SwitchCharacter(CharacterType type)
    {
        _audioSource.clip = _characterSwitchingAudio[(int)type];
        _audioSource.Play();
    }

    public void PlayAudio(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
