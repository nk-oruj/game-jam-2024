using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void StartGame()
    {
        UIManager.Instance.StartGame();
        CharacterSwitchManager.Instance.SwitchCharacter(CharacterType.Mike);
    }

    public void QuitGame()
    {
        UIManager.Instance.QuitGame();
    }
}
