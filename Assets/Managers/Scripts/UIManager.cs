using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    
    public void SwitchCharacter(CharacterType type)
    {
        CharacterSwitchManager.Instance.SwitchCharacter(type);
    }
}
