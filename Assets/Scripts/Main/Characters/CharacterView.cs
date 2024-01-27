using UnityEngine;

public class CharacterView : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    public void Flip(float direction)
    {
        if (direction > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }

    public void Idle()
    {
        _animator.SetFloat("Move", 0f);
    }

    public void Run()
    {
        _animator.SetFloat("Move", .5f);
    }

    public void Push()
    {
        _animator.SetFloat("Move", 1f);
    }
}
