using System.Collections.Generic;

public class CharacterSwitchManager : Singleton<CharacterSwitchManager>
{
    private Dictionary<CharacterType, AbstractCharacter> _characters = new Dictionary<CharacterType, AbstractCharacter>();
    private AbstractCharacter _currentCharacter;
    private CameraController _cameraController;


    private void Start()
    {
        _cameraController = CameraController.Instance;
    }

    public void SwitchCharacter(CharacterType type)
    {
        if (_currentCharacter == null || type != _currentCharacter.type)
        {
            if (_currentCharacter != null)
            {
                _currentCharacter.UnsubsribeFromControl();
                AudioManager.Instance.SwitchCharacter(type);
            }
            _currentCharacter = _characters[type];
            _currentCharacter.SubscribeToControl();

            _cameraController.SetTarget(_currentCharacter.transform);
        }
    }

    public void AddCharacter(CharacterType type, AbstractCharacter character)
    {
        _characters[type] = character;
    }
}
