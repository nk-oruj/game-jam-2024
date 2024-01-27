using UnityEngine;

public class CharacterSwitchingButton : MonoBehaviour
{
    [SerializeField] private CharacterType _type;

    public void SwitchCharacter()
    {
        UIManager.Instance.SwitchCharacter(_type);
    }
}
