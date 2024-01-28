using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private AudioClip clip;

    private void Start()
    {
        GameManager.Instance.WinEvent += () =>
        {
            GetComponent<SpriteRenderer>().sprite = sprite;
            AudioManager.Instance.PlayAudio(clip);
        };
    }
}
