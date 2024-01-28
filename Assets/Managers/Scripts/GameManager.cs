using System;

public class GameManager : Singleton<GameManager>
{
    public event Action ParrotSwitchEvent;

    private bool _isParrotSwiched = false;

    public void OnParrotSwitch()
    {
        if (!_isParrotSwiched)
        {
            ParrotSwitchEvent?.Invoke();
            _isParrotSwiched = true;
        }
    }
}
