using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(PlayerAnimator), typeof(PlayerMover))]
public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMover _mover;
    private PlayerAnimator _animator;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<PlayerMover>();
        _animator = GetComponent<PlayerAnimator>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.DirectionX != 0 || _inputReader.DirectionY != 0)
        {
            _animator.SetSpeedX(_inputReader.DirectionX);
            _animator.SetSpeedY(_inputReader.DirectionY);
            _mover.Move(new Vector2(_inputReader.DirectionX, _inputReader.DirectionY), _inputReader.IsDash);
        }
    }
}