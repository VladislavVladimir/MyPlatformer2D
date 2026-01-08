using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class Switch : MonoBehaviour, IInteractable
{
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _collider;

    public bool IsActive { get; private set; }

    public event Action<bool> OnStateChanged;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        IsActive = _spriteRenderer.enabled;
        _collider = GetComponent<BoxCollider2D>();
    }

    public void Interact()
    {
        IsActive = !IsActive;
        _spriteRenderer.enabled = IsActive;

        OnStateChanged?.Invoke(IsActive);
    }

    public void Disable()
    {
        _collider.enabled = false;
    }
}