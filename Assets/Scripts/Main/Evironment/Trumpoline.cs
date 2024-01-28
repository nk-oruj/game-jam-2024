using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trumpoline : InteractableObject
{
    private Transform _transform;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _transform = transform;
    }

    public void TrumpolineJump()
    {
        // Destroy(_transform.parent.GetComponent<Rigidbody2D>());
        _animator.SetTrigger("Jump");
    }
}
