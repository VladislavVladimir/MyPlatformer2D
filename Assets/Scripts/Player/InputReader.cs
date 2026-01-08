using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const string FIRE_1_AXIS = "Fire1";

    public float DirectionX { get; private set; }
    public float DirectionY { get; private set; }
    public bool IsDash { get; private set; }

    private bool _isInteract;

    private void Update()
    {
        DirectionX = Input.GetAxis(HORIZONTAL_AXIS);
        DirectionY = Input.GetAxis(VERTICAL_AXIS);
        IsDash = Input.GetButton(FIRE_1_AXIS);
        if (Input.GetKeyDown(KeyCode.F))
            _isInteract = true;
    }

    public bool GetIsInteract()
    {
        bool trigger = _isInteract;
        _isInteract = false;
        return trigger;
    }
}