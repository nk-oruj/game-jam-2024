using UnityEngine;

public class CharacterSwitchManager : MonoBehaviour
{
    [SerializeField] private AbstractCharacter _character;

    private void Start()
    {
        _character.SubscribeToControl();
    }
}
