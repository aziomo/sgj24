using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private float _scrollOffset;
    [SerializeField] private Vector2 _scrollRange;

    private void Update()
    {
        var position = transform.position;
        position.z = ((((Time.time + 100f) * _scrollSpeed) + _scrollOffset) % (_scrollRange.y - _scrollRange.x)) + _scrollRange.x;
        transform.position = position;
    }
}
