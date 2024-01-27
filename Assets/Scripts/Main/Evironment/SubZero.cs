using UnityEngine;

public class SubZero : InteractableObject
{
    public override void Interact(CharacterType type)
    {
        base.Interact(type);
        if (type == CharacterType.Mike) return;
        AllowMikeHitting();
        Destroy(transform.parent.gameObject);
    }

    private void AllowMikeHitting()
    {
        
        FindObjectsOfType<Mike>()[0].GetComponent<Mike>().AllowHitting();
    }
}
