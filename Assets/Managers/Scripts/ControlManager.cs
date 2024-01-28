using System;
using UnityEngine;
using UnityEngine.Serialization;

public class ControlManager : Singleton<ControlManager>
{
    public event Action<Vector2> MoveEvent;
    public event Action<Vector2> HitEvent;
    public event Action HitExit;

    public event Action InteractEvent;
    public event Action StopInteractEvent;
    public event Action AbilityEvent;
    public event Action AbilityStopEvent;

    [SerializeField] private string _horizontalAxisName;
    [SerializeField] private string _verticalAxisName;
    
    [SerializeField] private KeyCode _interactKey;
    [SerializeField] private KeyCode _abilityKey;
    
    [FormerlySerializedAs("_shootKey")] [SerializeField] private KeyCode _hitKey;

    private void Update()
    {
        float horizontalInput = Input.GetAxis(_horizontalAxisName);
        float verticalInput = Input.GetAxis(_verticalAxisName);

        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        OnMove(direction);

        if (Input.GetKeyDown(_abilityKey))
        {
            OnAbilityUse();
        }
        if (Input.GetKeyUp(_abilityKey))
        {
            OnAbilityStop();
        }

        if (Input.GetKeyDown(_interactKey)){
            OnInteract();
        }
        if (Input.GetKeyUp(_interactKey))
        {
            OnStopInteract();
        }

        if (Input.GetKeyDown(_hitKey))
        {
            OnHitEvent(Input.mousePosition);
        }
        if (Input.GetKeyUp(_hitKey))
        {
            OnHitExitEvent();
        }
    }

    private void OnHitExitEvent()
    {
        HitExit?.Invoke();
    }

    private void OnMove(Vector2 direction)
    {
        MoveEvent?.Invoke(direction);
    }

    private void OnHitEvent(Vector2 mousePosition)
    {
        HitEvent?.Invoke(mousePosition);
    }
    
    private void OnInteract()
    {
        InteractEvent?.Invoke();
    }

    private void OnStopInteract()
    {
        StopInteractEvent?.Invoke();
    }

    private void OnAbilityUse()
    {
        AbilityEvent?.Invoke();
    }

    private void OnAbilityStop()
    {
        AbilityStopEvent?.Invoke();
    }
}
