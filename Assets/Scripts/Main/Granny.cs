using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granny : AbstractCharacter
{
    private enum BehaviorState
    {
        Idle,
        Walk
    }

    private BehaviorState _state = BehaviorState.Idle;
    private Vector2 _direction = Vector2.left;
    private bool _isFallen = false;
    private bool _isFalling = false;


    private void Update()
    {
        if(_state == BehaviorState.Walk)
        {
            Move(_direction);
        }
    }

    private void FixedUpdate()
    {
        if (_isFalling)
        {
            Fall();
        }
    }

    public void ParrotEscape()
    {
        _state = BehaviorState.Walk;
    }

    private void Banana()
    {
        if (!_isFallen)
        {
            _state = BehaviorState.Idle;
            _isFalling = true;
        }
    }

    private void Fall()
    {
        float step = 3f;

        transform.rotation = transform.rotation * Quaternion.Euler(Vector3.forward * step);

        if (transform.rotation.eulerAngles.z > 90f)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            _isFallen = true;
            _isFalling = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Banana();
        }
    }
}
