using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ShelfTrigger"))
        {
            gameObject.layer = 0;
            collision.transform.parent.tag = "MoveableBlock";
            collision.transform.parent.gameObject.layer = 0;
        }
    }
}
