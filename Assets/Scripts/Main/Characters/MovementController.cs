using System;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isFlying;
    [SerializeField] private float _airFriction;

    private Rigidbody2D _rigidbody;
    private Vector2 _externalVelocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Walk(float direction)
    {
        if (direction == 0)
        {
            _externalVelocity = Vector2.zero;
            if (_isFlying)
            {
                _rigidbody.velocity -= Vector2.right * _rigidbody.velocity.x;
            }
        }
        else
        {
            _externalVelocity = new Vector2(direction * (_speed - Mathf.Abs(_rigidbody.velocity.x)), 0);
            if (Mathf.Sign(_rigidbody.velocity.x / direction) >= 0 && Mathf.Abs(_rigidbody.velocity.x) > Mathf.Abs(_externalVelocity.x))
            {
                _externalVelocity = Vector2.zero;
            }
        }

        _rigidbody.velocity += _externalVelocity;
    }
}
