using System;
using UnityEngine;

public class ControlManager : Singleton<ControlManager>
{
    public event Action<Vector2> MoveEvent;

    [SerializeField] private string _horizontalAxisName;
    [SerializeField] private string _verticalAxisName;


    private void Update()
    {
        float horizontalInput = Input.GetAxis(_horizontalAxisName);
        float verticalInput = Input.GetAxis(_verticalAxisName);
        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector2 direction = new Vector2(horizontalInput, verticalInput);
            OnMove(direction);
        }
    }

    private void OnMove(Vector2 direction)
    {
        MoveEvent?.Invoke(direction);
    }
}
