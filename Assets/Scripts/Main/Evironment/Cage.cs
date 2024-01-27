using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "SubZero") return;

        UIManager.Instance.EnableButtonParrot();
        Destroy(this.gameObject);
    }
}
