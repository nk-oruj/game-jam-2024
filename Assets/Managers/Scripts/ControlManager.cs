using System;
using UnityEngine;

public class ControlManager : Singleton<ControlManager>
{
    public event Action<Vector2> MoveEvent;
    public event Action InteractEvent;
    public event Action StopInteractEvent;

    [SerializeField] private string _horizontalAxisName;
    [SerializeField] private string _verticalAxisName;
    [SerializeField] private KeyCode _interactKey;

    private void Update()
    {
        float horizontalInput = Input.GetAxis(_horizontalAxisName);
        float verticalInput = Input.GetAxis(_verticalAxisName);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector2 direction = new Vector2(horizontalInput, verticalInput);
            OnMove(direction);
        }

        if (Input.GetKeyDown(_interactKey)){
            OnInteract();
        }
        if (Input.GetKeyUp(_interactKey))
        {
            OnStopInteract();
        }
    }

    private void OnMove(Vector2 direction)
    {
        MoveEvent?.Invoke(direction);
    }

    private void OnInteract()
    {
        InteractEvent?.Invoke();
    }

    private void OnStopInteract()
    {
        StopInteractEvent?.Invoke();
    }
}
