using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(BoxCollider2D))]
public class Finish : MonoBehaviour, IInteractable
{
    public static readonly int UNLOCKED = Animator.StringToHash("Unlocked");
    public static readonly int FINISHED = Animator.StringToHash("Finished");

    private Animator _animator;
    private Switch[] _switches;

    private bool _isUnlocked = false;
    private int _activeSwitchesCount = 0;

    private void Start()
    {
        foreach (var _switch in _switches)
        {
            _switch.OnStateChanged += OnSwitchStateChanged;

            if (_switch.IsActive)
                _activeSwitchesCount++;
        }

        print(_activeSwitchesCount);
        print(_switches.Length);

        CheckIfAllSwitchesActive();
    }

    private void OnDestroy()
    {
        foreach (var _switch in _switches)
            _switch.OnStateChanged -= OnSwitchStateChanged;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _switches = GetComponentsInChildren<Switch>();
    }

    public void Interact()
    {
        if (_isUnlocked)
        {
            _isUnlocked = true;
            _animator.SetTrigger(FINISHED);
        }
    }

    private void OnSwitchStateChanged(bool isActive)
    {
        if (isActive)
            _activeSwitchesCount++;
        else
            _activeSwitchesCount--;

        print(_activeSwitchesCount);
        print(_switches.Length);

        CheckIfAllSwitchesActive();
    }

    private void CheckIfAllSwitchesActive()
    {
        if (_activeSwitchesCount == _switches.Length)
        {
            _isUnlocked = true;
            _animator.SetTrigger(UNLOCKED);
            foreach (var _switch in _switches)
                _switch.Disable();
        }
    }
}