using UnityEngine;

public class Slider : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
