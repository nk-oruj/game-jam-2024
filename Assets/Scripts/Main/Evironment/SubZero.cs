using UnityEngine;

public class SubZero : InteractableObject
{
    public override void Interact(CharacterType type)
    {
        base.Interact(type);
        AllowMikeHitting();
        Destroy(gameObject);
    }

    private void AllowMikeHitting()
    {
        FindObjectsOfType<Mike>()[0].GetComponent<Mike>().AllowHitting();
    }
}
