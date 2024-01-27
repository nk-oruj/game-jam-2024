using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private Rigidbody2D _rigidbody;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetFlyingDirection(Vector2 direction)
    {
        _rigidbody.velocity =_speed * new Vector3(direction.x, direction.y, transform.position.z).normalized;
    }

    
    
}
