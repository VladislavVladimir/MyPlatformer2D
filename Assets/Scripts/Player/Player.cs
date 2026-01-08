using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(PlayerAnimator), typeof(PlayerMover))]
[RequireComponent(typeof(CollisionHandler))]
public class Player : MonoBehaviour
{
    private InputReader _inputReader;
    private PlayerMover _mover;
    private PlayerAnimator _animator;
    private CollisionHandler _collisionHandler;

    private IInteractable _interactable;

    private void OnEnable()
    {
        _collisionHandler.Interacted += OnInteracted;
    }

    private void OnDisable()
    {
        _collisionHandler.Interacted -= OnInteracted;
    }

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _mover = GetComponent<PlayerMover>();
        _animator = GetComponent<PlayerAnimator>();
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void FixedUpdate()
    {
        if (_inputReader.DirectionX != 0 || _inputReader.DirectionY != 0)
        {
            _animator.SetSpeedX(_inputReader.DirectionX);
            _animator.SetSpeedY(_inputReader.DirectionY);
            _mover.Move(new Vector2(_inputReader.DirectionX, _inputReader.DirectionY), _inputReader.IsDash);
        }

        if (_inputReader.GetIsInteract() && _interactable != null)
            _interactable.Interact();
    }

    private void OnInteracted(IInteractable interactable)
    {
        _interactable = interactable;
    }
}