using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Ground") return;


        gameObject.tag = "Banana";
        Destroy(GetComponent<Rigidbody2D>());
        GetComponent<BoxCollider2D>().isTrigger = true;
        _animator.SetTrigger("Fall");
        AudioManager.Instance.PlayAudio(_audioClip);
    }
}
