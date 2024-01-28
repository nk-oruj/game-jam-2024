using System;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _string;
    [SerializeField] private Collider2D _core;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Laser"))
        {
            if (_string != null) Destroy(_string);

            _rigidbody.gravityScale = 1;
            _core.isTrigger = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            Destroy(_rigidbody);
            GetComponentInChildren<Collider2D>().isTrigger = true;
        }
    }

    public void MakeCoreTrigger()
    {
        _core.isTrigger = true;
    }
}
