using UnityEngine;

public class AbstractCharacter : MonoBehaviour
{
    private ControlManager _controlManager;

    private void Start()
    {
        _controlManager = ControlManager.Instance;
    }

    protected virtual void Move(Vector2 direction)
    {

    }

    protected virtual void Interact()
    {

    }


    public void SubscribeToControl()
    {
        _controlManager.MoveEvent += Move;
        _controlManager.InteractEvent += Interact;
    }

    public void UnsubsribeFromControl()
    {
        _controlManager.MoveEvent -= Move;
        _controlManager.InteractEvent -= Interact;
    }
}
