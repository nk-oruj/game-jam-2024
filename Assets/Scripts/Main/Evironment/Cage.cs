using UnityEngine;

public class Cage : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;

    private bool _isBroken;

    private void Awake()
    {
        _isBroken = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isBroken) return;
        if (other.gameObject.tag != "InteractableObject") return;
        if (other.GetComponent<Bullet>() == null) return;

        other.GetComponent<Collider2D>().isTrigger = true;
        GetComponent<SpriteRenderer>().sprite = _sprite;
        GetComponent<SpriteRenderer>().sortingOrder = -1;

        UIManager.Instance.EnableButtonParrot();
        _isBroken = true;
    }
}
