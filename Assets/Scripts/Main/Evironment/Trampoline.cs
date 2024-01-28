using System;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Laser"))
        {
            Destroy(transform.GetChild(0).gameObject);
            _rigidbody.gravityScale = 1;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            Destroy(_rigidbody);
        }
    }
}
