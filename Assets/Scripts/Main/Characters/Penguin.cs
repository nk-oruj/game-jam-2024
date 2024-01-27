using UnityEngine;

public class Penguin : AbstractCharacter
{
    [SerializeField] private PhysicsMaterial2D _physicMaterial;

    private float _defaultFriction;

    protected override void Start()
    {
        base.Start();
        _defaultFriction = _physicMaterial.friction;
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
        _physicMaterial.friction = 0;
    }

    private void StopSlide()
    {
        _physicMaterial.friction = _defaultFriction;
    }
}
