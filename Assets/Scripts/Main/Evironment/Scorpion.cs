using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : InteractableObject
{
    public override void Interact(CharacterType type, GameObject interactObject = null)
    {
        base.Interact(type);
        if (type != CharacterType.Mike) return;
        AllowMikeHitting();
        Destroy(transform.parent.gameObject);
    }

    private void AllowMikeHitting()
    {
        FindObjectsOfType<Mike>()[0].GetComponent<Mike>().AllowHitting(false);
    }
}
