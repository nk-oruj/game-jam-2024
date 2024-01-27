using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitchManager : Singleton<CharacterSwitchManager>
{
    private Dictionary<CharacterType, AbstractCharacter> _characters = new Dictionary<CharacterType, AbstractCharacter>();
    private AbstractCharacter _currentCharacter;

    
    private void Start()
    {
        _currentCharacter = _characters[CharacterType.Parrot];
        _currentCharacter.SubscribeToControl();
    }

    public void SwitchCharacter(CharacterType type)
    {
        if (type == _currentCharacter.type) return;
        
        _currentCharacter.UnsubsribeFromControl();
        _currentCharacter = _characters[type];
        _currentCharacter.SubscribeToControl();
    }

    public void AddCharacter(CharacterType type, AbstractCharacter character)
    {
        _characters[type] = character;
    }
}
