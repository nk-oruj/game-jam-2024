using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Walk(float direction)
    {
        if (direction != 0) {
            _rigidbody.velocity = new Vector2(direction * _speed, _rigidbody.velocity.y);
        }
    }
}
