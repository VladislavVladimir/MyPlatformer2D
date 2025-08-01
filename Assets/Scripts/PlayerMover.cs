using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const float SPEED_COEFFICIENT = 50f;
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const string FIRE_1_AXIS = "Fire1";

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

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = Time.fixedDeltaTime * SPEED_COEFFICIENT * GetMovementVectorWithDashTimerUpdate();
    }

    private Vector2 GetMovementVectorWithDashTimerUpdate()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis(HORIZONTAL_AXIS), Input.GetAxis(VERTICAL_AXIS));
        if (moveInput.sqrMagnitude > 1f)
        {
            moveInput.Normalize();
        }

        if (_dashTimer > 0)
        {
            _dashTimer -= Time.fixedDeltaTime;
            return moveInput * _dashSpeed;
        }
        else if (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.fixedDeltaTime;
        }

        return moveInput * _moveSpeed;
    }

    private void Update()
    {
        if (Input.GetAxisRaw(FIRE_1_AXIS) != 0)
        {
            if (_cooldownTimer <= 0 && (Input.GetAxis(HORIZONTAL_AXIS) != 0 || Input.GetAxis(VERTICAL_AXIS) != 0))
            {
                _dashTimer = _dashDuration;
                _cooldownTimer = _dashCooldown;
            }
        }
    }
}
