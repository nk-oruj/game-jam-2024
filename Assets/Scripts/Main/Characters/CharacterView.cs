using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Flip(float direction)
    {
        if (direction > 0)
        {
            _spriteRenderer.flipY = false;
        }
        else
        {
            _spriteRenderer.flipY = true;
        }
    }
}
