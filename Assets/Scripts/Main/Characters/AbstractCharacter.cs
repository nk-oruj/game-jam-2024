using UnityEngine;

public class AbstractCharacter : MonoBehaviour
{
    public CharacterType type;
    
    private ControlManager _controlManager;
    private MovementController _movementController;
    private CharacterView _view;

    protected bool _isAbilityPressed = false;
    protected bool _isInteractionPressed = false;
    protected Vector2 _currentDirection;

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
        _currentDirection = direction;
    }

    protected virtual void Interact()
    {
        _isInteractionPressed = true;
    }

    protected virtual void StopInteract()
    {
        _isInteractionPressed = false;
    }

    protected virtual void UseAbility()
    {
        _isAbilityPressed = true;
    }

    protected virtual void StopAbility()
    {
        _isAbilityPressed = false;
    }

    protected virtual void Hit(Vector2 mousePosition)
    {
        
    }

    protected virtual void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("InteractableObject") && _isInteractionPressed)
        {
            other.gameObject.GetComponent<InteractableObject>().Interact(type);
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("InteractableObject") && _isInteractionPressed)
        {
            other.gameObject.GetComponent<InteractableObject>().Interact(type);
        }
    }


    public void SubscribeToControl()
    {
        _controlManager.MoveEvent += Move;
        _controlManager.InteractEvent += Interact;
        _controlManager.StopInteractEvent += StopInteract;
        _controlManager.AbilityEvent += UseAbility;
        _controlManager.AbilityStopEvent += StopAbility;
        _controlManager.HitEvent += Hit;
    }

    public void UnsubsribeFromControl()
    {
        _controlManager.MoveEvent -= Move;
        _controlManager.InteractEvent -= Interact;
        _controlManager.StopInteractEvent -= StopInteract;
        _controlManager.AbilityEvent -= UseAbility;
        _controlManager.AbilityStopEvent -= StopAbility;
        _controlManager.HitEvent -= Hit;

    }
}
