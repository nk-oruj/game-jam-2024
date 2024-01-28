using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionProjectile : MonoBehaviour
{
    public bool _isShooted;

    private Transform _targetPosition;
    private bool _isMoving;

    private void FixedUpdate()
    {
        if(_isMoving && Vector2.Distance(_targetPosition.position, transform.position) > 0.5f)
        {
            transform.position += (_targetPosition.position - transform.position).normalized * Time.deltaTime * 3;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isShooted && other.gameObject.layer == 6 && other.gameObject.GetComponent<AbstractCharacter>().type == CharacterType.Granny)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            _targetPosition = other.gameObject.GetComponent<Granny>().TargetPosition;
            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            other.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            other.gameObject.GetComponent<Granny>().Idle();
            other.transform.parent = transform;
            _isMoving = true;
        }
    }
}
