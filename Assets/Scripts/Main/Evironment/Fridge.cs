using UnityEngine;

public class Fridge : InteractableObject
{
    [SerializeField] private Sprite _openedSprite;
    [SerializeField] private AudioClip _openAudio;

    private SpriteRenderer _renderer;
    private bool _isOpened;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public override void Interact(CharacterType type)
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
        _renderer.sprite = _openedSprite;
        AudioManager.Instance.PlayAudio(_openAudio);
    }

}
