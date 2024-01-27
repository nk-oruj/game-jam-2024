using UnityEngine;

public class AbstractCharacter : MonoBehaviour
{
    public CharacterType type;
    
    private ControlManager _controlManager;
    private MovementController _movementController;
    private CharacterView _view;

    protected virtual void Awake()
    {
        _controlManager = ControlManager.Instance;

        CharacterSwitchManager.Instance.AddCharacter(type, this);
    }

    protected virtual void Start()
    {
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
