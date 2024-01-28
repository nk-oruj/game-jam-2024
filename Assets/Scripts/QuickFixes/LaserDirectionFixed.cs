using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.U2D.Animation;

public class LaserDirectionFixed : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sr;
    private float xPos;

    private void Start()
    {
        xPos = transform.localPosition.x;
    }

    private void Update()
    {
        transform.localPosition = new Vector3(xPos * (_sr.flipX ? -1 : 1), transform.localPosition.y);
    }
}
