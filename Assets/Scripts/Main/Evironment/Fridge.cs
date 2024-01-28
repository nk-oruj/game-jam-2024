using UnityEngine;
using System.Collections;

public class Fridge : InteractableObject
{
    [SerializeField] private Sprite _openedSprite;
    [SerializeField] private AudioClip _openAudio;
    [SerializeField] private GameObject _penguin;
    [SerializeField] private GameObject _slider;

    private SpriteRenderer _renderer;
    private AudioSource _audioSource;
    private bool _isOpened;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Interact(CharacterType type, GameObject interactObject = null)
    {
        base.Interact(type);
        TryToOpen(type);
    }

    private void TryToOpen(CharacterType type)
    {
        if (!_isOpened)
        {
            if (type != CharacterType.Granny)
            {
                Debug.Log("Idi naxuy");
            }
            else
            {
                Open();
            }
        }
    }

    private void Open()
    {
        _isOpened = true;
        _audioSource.loop = false;
        _audioSource.clip = _openAudio;
        _audioSource.Play();

        StartCoroutine(OpenDelay(3f));
    }

    private IEnumerator OpenDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _renderer.sprite = _openedSprite;
        _renderer.sortingOrder = -2;
        _slider.SetActive(true);
        _penguin.SetActive(true);
        UIManager.Instance.EnableButtonPinguin();
    }

}
