using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float SPEED_COEFFICIENT = 50f;

    [SerializeField] private float _moveSpeed = 5f;
    [Header("Dash Settings")]
    [SerializeField] private float _dashSpeed = 20f;
    [SerializeField] private float _dashDuration = 0.2f;
    [SerializeField] private float _dashCooldown = 1f;

    private Rigidbody2D _rigidbody2D;
    private float _dashTimer;
    private float _cooldownTimer;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction, bool isDush)
    {
        if (direction.sqrMagnitude > 1f)
            direction.Normalize();

        float currentSpeed = _moveSpeed;
        if (_cooldownTimer > 0f) 
        {
            _cooldownTimer -= Time.fixedDeltaTime;
        } 
        else if (isDush)
        {
            _dashTimer -= Time.fixedDeltaTime;
            currentSpeed = _dashSpeed;
        }

        if (_dashTimer <= 0f)
        {
            _dashTimer = _dashDuration;
            _cooldownTimer = _dashCooldown;
        }

        Vector3 pos = transform.position;
        pos.z = pos.y - 0.25f;
        transform.position = pos;
        _rigidbody2D.velocity = Time.fixedDeltaTime * SPEED_COEFFICIENT * direction * currentSpeed;
    }
}