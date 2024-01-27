using UnityEngine;

public class Penguin : AbstractCharacter
{
    [SerializeField] private PhysicsMaterial2D _slidePhysicMaterial;
    [SerializeField] private PhysicsMaterial2D _defaultPhysicMaterial;

    private Rigidbody2D _rigidbody;
    private bool _isSliding;

    protected override void Start()
    {
        base.Start();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!_isSliding)
        {
            Stand();
        }
    }

    protected override void Interact()
    {
        Slide();
    }

    protected override void StopInteract()
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
        float currentRotation = transform.rotation.z;
        float step = 1f;

        if(Mathf.Abs(currentRotation) > 0.1f)
        {
            transform.rotation = transform.rotation * Quaternion.Euler(Vector3.back * Mathf.Sign(currentRotation) * step);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
