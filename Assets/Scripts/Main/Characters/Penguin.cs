using UnityEngine;

public class Penguin : AbstractCharacter
{
    [SerializeField] private PhysicsMaterial2D _slidePhysicMaterial;
    [SerializeField] private PhysicsMaterial2D _defaultPhysicMaterial;
    [SerializeField] private GameObject _slider;

    private Transform _transform;
    private Rigidbody2D _rigidbody;

    private bool _isSliding;
    private bool _isJumping;


    protected override void Start()
    {
        base.Start();

        _transform = transform;
        _rigidbody = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (!_isSliding)
        {
            Stand();
        }
    }

    protected override void UseAbility()
    {
        Slide();
    }

    protected override void StopAbility()
    {
        StopSlide();
    }

    private void Slide()
    {
        _rigidbody.sharedMaterial = _slidePhysicMaterial;
        _rigidbody.freezeRotation = false;
        _isSliding = true;
    }

    private void StopSlide()
    {
        _rigidbody.sharedMaterial = _defaultPhysicMaterial;
        _rigidbody.freezeRotation = true;
        _isSliding = false;
    }

    private void Stand()
    {
        float currentRotation = _transform.rotation.z;
        float step = 1f;

        if (Mathf.Abs(currentRotation) > 0.1f)
        {
            _transform.rotation = _transform.rotation * Quaternion.Euler(Vector3.back * Mathf.Sign(currentRotation) * step);
        }
        else
        {
            _transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isJumping = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isJumping = false;
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        base.OnTriggerStay2D(other);

        if (other.gameObject.tag != "Trumpoline") return;
        if (!_isInteractionPressed) return;
        if (_isJumping) return;

        Transform _trumpolineTransform = other.transform;

        _trumpolineTransform.GetComponent<Trumpoline>().TrumpolineJump();

        _transform.position = _trumpolineTransform.position;
        _rigidbody.AddForce(12f * Vector3.up, ForceMode2D.Impulse);

        _isJumping = true;
    }
}
