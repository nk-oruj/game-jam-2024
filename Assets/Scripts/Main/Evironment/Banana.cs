using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Ground") return;

        // change sprite
        gameObject.tag = "Banana";
        Destroy(GetComponent<Rigidbody2D>());
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Animator>().SetTrigger("Ground");
    }
}
