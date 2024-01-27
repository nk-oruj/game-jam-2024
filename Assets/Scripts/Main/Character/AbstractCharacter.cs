using UnityEngine;

public class AbstractCharacter : MonoBehaviour
{
    public CharacterType type;
    
    private ControlManager _controlManager;
    private MovementController _movementController;
    private CharacterView _view;

    private void Awake()
    {
        CharacterSwitchManager.Instance.AddCharacter(type, this);
    }

    private void Start()
=======
    protected virtual void Awake()
>>>>>>> 151ab162d0931a979cfb3c80ea6dedbd5347ead1:Assets/Scripts/Main/Characters/AbstractCharacter.cs
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
