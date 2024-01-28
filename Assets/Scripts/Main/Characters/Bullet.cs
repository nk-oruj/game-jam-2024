using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private bool _hittedObject = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetFlyingDirection(Vector2 direction)
    {
        _rigidbody.AddForce(_speed * new Vector3(direction.x, direction.y, transform.position.z).normalized, ForceMode2D.Impulse);
        AudioManager.Instance.PlayAudio(_audioClip);
    }

    private void Update()
    {
        if (!_hittedObject) transform.up = _rigidbody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _hittedObject = true;
    }
}
