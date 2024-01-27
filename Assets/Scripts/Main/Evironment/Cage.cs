using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    private Transform _transform;
    private bool _isBroken;

    private void Awake()
    {
        _transform = transform;
        _isBroken = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isBroken) return;
        if (other.gameObject.tag != "SubZero") return;

        UIManager.Instance.EnableButtonParrot();
        _transform.Rotate(new Vector3(0, 0, 45f));

        _isBroken = true;
    }
}
