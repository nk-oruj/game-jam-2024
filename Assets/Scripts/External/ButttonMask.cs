using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ButttonMask : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float _alpha = 1f;
    private Image _imageButton;

    private void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = _alpha;
    }
}
