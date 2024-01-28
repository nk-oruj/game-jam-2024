using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InteractableObject
{
    public override void Interact(CharacterType type, GameObject interactObject) {
        if(type == CharacterType.Penguin)
        {
            transform.parent = interactObject.transform;
        }
    }
}
