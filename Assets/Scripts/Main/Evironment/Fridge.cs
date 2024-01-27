using UnityEngine;

public class Fridge : InteractableObject
{
    public override void Interact(CharacterType type)
    {
        base.Interact(type);
        TryToOpen(type);
    }

    private void TryToOpen(CharacterType type)
    {
        if(type != CharacterType.Granny)
        {
            Debug.Log("Idi naxuy");
        }
        else
        {
            Open();
        }
    }

    private void Open()
    {

    }

}
