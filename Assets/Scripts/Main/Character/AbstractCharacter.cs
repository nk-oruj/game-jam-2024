using UnityEngine;

public class AbstractCharacter : MonoBehaviour
{
    private ControlManager _controlManager;
    private MovementController _movementController;
    private CharacterView _view;

    private void Awake()
    {
        _controlManager = ControlManager.Instance;

        _movementController = GetComponent<MovementController>();
        _view = GetComponentInChildren<CharacterView>();
    }

    protected virtual void Move(Vector2 direction)
    {
        _movementController.Walk(direction.x);
        _view.Flip(direction.x);
    }

    protected virtual void Interact()
    {

    }

    protected virtual void StopInteract()
    {

    }


    public void SubscribeToControl()
    {
        _controlManager.MoveEvent += Move;
        _controlManager.InteractEvent += Interact;
        _controlManager.StopInteractEvent += StopInteract;
    }

    public void UnsubsribeFromControl()
    {
        _controlManager.MoveEvent -= Move;
        _controlManager.InteractEvent -= Interact;
        _controlManager.StopInteractEvent -= StopInteract;
    }
}
