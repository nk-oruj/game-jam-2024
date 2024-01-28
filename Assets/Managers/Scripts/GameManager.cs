using System;

public class GameManager : Singleton<GameManager>
{
    public event Action ParrotSwitchEvent;
    public event Action TakeKeyEvent;
    public event Action WinEvent;

    private bool _isParrotSwiched = false;

    public void OnParrotSwitch()
    {
        if (!_isParrotSwiched)
        {
            ParrotSwitchEvent?.Invoke();
            _isParrotSwiched = true;
        }
    }

    public void TakeKey()
    {
        TakeKeyEvent?.Invoke();
    }

    public void Win()
    {
        WinEvent?.Invoke();
    }
}
